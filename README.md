# Omega Project
After Create Omega directory run these commands to create project:
```bash
cd ./Omega
mkdir App 
cd ./App
dotnet new web
cd ..\
dotnet new sln
dotnet sln add .\App
cd ./App
dotnet run
```
- Modify launchSettings.json in \Omega\App\Properties\launchSettings.json directory and remove https from applicationUrl ;
- Modify your Startup.cs and write your script (in this case Added a new MapGet and context.Response to POW 2 entities) 

## Quickstart Docker time:
Start omega using:
```bash
docker run -it -p 5000:80 --rm ghcr.io/rfinland/omega:master
```
Then 
```bash
curl "http://localhost:5000/POW?a=2&b=3"
```

Set your Dsn to Program.cs and to catching exception on your Sentry Server :
```bash
curl "http://localhost:5000/Exception"
```
Put your FrontEnd file in :/root/dotnet/Omega/  then:
```bash
docker run -it -p 5000:80 -v /root/dotnet/Omega/:/app/FrontEnd --rm ghcr.io/rfinland/omega:master
```
