# 262181 Web Application Development - Minimalistischer Webserver
Webserver for static files. Serves files from folder `wwwroot`. If `http://localhost/foo/bar.xml` is called then file `${workingDirectory}/wwwroot/foo/bar.xml` is served.

Project files are are generated from with `dotnet publish --configuration Release`  
Some seemingly uneccessary files are removed.  
`README.md` and `LICENSE` are added.

Author: 199067, Simon Stratemeier

## Requirements
- .NET Core 3.1

## Run project
`dotnet Web-Application-Development.dll`  
Sudo might be required in order to bind to port 80. 

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

## Testing with telnet
1. Run `dotnet Web-Application-Development.dll`  
2. Open telnet connection in with `telnet localhost 80`
3. Insert into connection window the following text (don't forget the `\r\n`-linebreak at the last empty line) 
```
GET /index.html HTTP/1.1
Host: localhost
User-Agent: Mozilla/5.0

```
4. Expect something like the following response:
```
HTTP/1.1 200 OK
Date: Mon, 19 Oct 2020 21:24:42 GMT
Content-Type: text/html
Server: Kestrel
Content-Length: 139
Last-Modified: Mon, 19 Oct 2020 21:19:35 GMT
Accept-Ranges: bytes
ETag: "1d6a65d8b1b4d0b"

<!DOCTYPE html>
<html>
    <head>
        <title>Hello World</title>
    </head>
    <body>
        <p>Hello World!</p>
    </body>
</html>
```

## Source code
You might be able to find the source code under <https://github.com/sstratemeier/Web-Application-Development/>
