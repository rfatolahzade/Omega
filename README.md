# Omega Project
Step by step with dotnet web

## Quickstart
Start omega using:
```bash
docker run -it -p 5000:80 --rm ghcr.io/rfinland/omega:master
```
Then 
```bash
curl "http://localhost:5000/POW?a=2&b=3"
```
## Known issues
cannot convert from 'double' to 'string'
Just set:
```bash
await context.Response.WriteAsync(Math.Pow(a,b)); 
```
To 
```bash
await context.Response.WriteAsync("POW " + Math.Pow(a,b));
```
In Startup.cs then here you go (it'll be fix very soon...)
