FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY *.sln .
COPY App/*.csproj ./App/
RUN dotnet restore

COPY App/. ./App/
WORKDIR /source/App
RUN dotnet add package Sentry.AspNetCore -v 3.6.1
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
VOLUME app/FrontEnd
ENTRYPOINT ["dotnet", "App.dll"]