FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

COPY *.sln .
COPY App/*.csproj ./App/
RUN dotnet restore

COPY App/. ./App/
WORKDIR /source/App
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
<<<<<<< HEAD

ENTRYPOINT ["dotnet", "App.dll"]
=======
ENTRYPOINT ["dotnet", "DotnetWeb.dll"]
>>>>>>> eaacfe66d7c96ffb88cdc79d924ba9f180f0675e
