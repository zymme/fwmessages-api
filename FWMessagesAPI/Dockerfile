﻿FROM microsoft/aspnetcore-build:1.0-2.0 AS build-env
WORKDIR /app

LABEL maintainer="dsendtec@gmail.com"


# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore


# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/aspnetcore:2.0-jessie
WORKDIR /app


COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "FWMessagesAPI.dll"]