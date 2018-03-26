using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

using Microsoft.Extensions.Logging;


using FWMessagesAPI.Services;
using FWMessagesAPI.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FWMessagesAPI.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        private readonly IMessageBoardService _messageboardService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(ILogger<MessagesController> logger, IMessageBoardService messageBoardService)
        {
            _logger = logger;
            _messageboardService = messageBoardService;
        }
        
        [EnableCors("AllowAnyOrigin")]
        [HttpPost("/message")]
        public IActionResult CreateMessage([FromBody] MessageCreateDto msgToCreate) 
        {
            

            return Ok("Not Implemented Yet");
        }



        [EnableCors("AllowAnyOrigin")]
        [HttpPost("/messageboard")]
        public IActionResult CreateMessageBoardEntry([FromBody] MessageBoardForCreateDto msgboardcreate) 
        {
            try
            {
                Console.WriteLine("Entered CreateMessageBoardEntry() ");

                var resp = _messageboardService.AddMessageBoardEntry(msgboardcreate);

                return Ok(resp);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error in CreateMessageBoardEntry { e.Message }");
                _logger.LogError($"Error in CreateMessageBoardEntry { e.Message }");

                return StatusCode(500, e.Message);
            }

        }

    }
}
