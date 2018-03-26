using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using NLog.Extensions.Logging;

using Microsoft.EntityFrameworkCore;

using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using Swashbuckle.AspNetCore.SwaggerGen;

using FWMessagesAPI.Entities;
using FWMessagesAPI.Services;
using FWMessagesAPI.Repository;

namespace FWMessagesAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                             options.AddPolicy("AllowAnyOrigin", builder =>
                                               builder.AllowAnyHeader()
                                               .AllowAnyMethod()
                                               .AllowAnyOrigin()
                                               .AllowCredentials())
                            );

            services.AddMvc();

            var connectionString = Configuration["ConnectionStrings:DataAccessPostgreSqlProvider"];
            Console.WriteLine($"db conn string : {connectionString}");

            services.AddDbContext<MessagesContext>(o => o.UseNpgsql(connectionString,
                                                                b => b.MigrationsAssembly("FWMessagesAPI")));

            services.AddScoped<IMessageBoardService, MessageBoardService>();
            services.AddScoped<IMessagesRepository, MessagesRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "FWMessages API", Version = "v1", Description = "FWMessages API" });

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowAnyOrigin");


            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            loggerFactory.AddNLog();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Entities.Message, Models.MessageCreateDto>();
                cfg.CreateMap<Models.MessageCreateDto, Entities.Message>();
                cfg.CreateMap<Entities.MessageBoard, Models.MessageBoardForCreateDto>();
                cfg.CreateMap<Models.MessageBoardForCreateDto, Entities.MessageBoard>();
            });


            app.UseMvc();



            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FWMessages API");
                c.ShowRequestHeaders();
            });

        }
    }
}
