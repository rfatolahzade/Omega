# Omega Project
Step by step with dotnet web
```bash
dotnet new web
```
Modify launchSettings.json in \Omega\App\Properties\launchSettings.json directory and remove https from applicationUrl
Modify your Startup.cs and write your script (in this case Added a new MapGet and context.Response to POW 2 entities) 
## Quickstart
Start omega using:
```bash
docker run -it -p 5000:80 --rm ghcr.io/rfinland/omega:master
```
Then 
```bash
curl "http://localhost:5000/POW?a=2&b=3"
```