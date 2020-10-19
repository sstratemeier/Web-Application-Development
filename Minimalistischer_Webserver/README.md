# 262181 Web Application Development - Minimalistischer Webserver
Webserver for static files. Serves files from folder `wwwroot`. If `http://localhost/foo/bar.xml` is called then file `${workingDirectory}/wwwroot/foo/bar.xml` is served.


## Requirements
- .NET Core 3.1

## Routes
- `http://localhost:80/index.html` => serve index.html
- `http://localhost:80/foo/bar.xml` => serve bar.xml

## Port definition
The port is defined under `appsettings.json`
It can be changed by setting the Urls property. E.g. to port 8080:
```javascript
{
  ...
  "Urls": "http://localhost:8080"
}
```
