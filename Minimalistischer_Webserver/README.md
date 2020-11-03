# 262181 Web Application Development - CSS + HTML
Webserver for static files. Serves files from folder `wwwroot`. If `http://localhost/students/1/index.html` is called then file `${workingDirectory}/students/1/index.html` is served.

- Project initialized with `dotnet new web`  
- Gitignore generated with `dotnet new gitignore`

**Author:** 199067, Simon Stratemeier

## Requirements
- .NET Core 3.1

## Run project
Run `dotnet build` in project root directoy with project file `Web-Application-Development.csproj` to create executables.

From the project root directory you can run the executable with
`dotnet bin/Debug/netcoreapp3.1/Web-Application-Development.dll`.

Sudo might be required in order to bind the executable to port 80. 

## Publish Project
To generate a folder with a executable that can be run independenly from the root directory run `dotnet publish --configuration Release`. 
This not only builds a executable but also adds dependencys like the `wwwroot` folder for static files.

The files are generated in `{rootDirectory}/bin/Release/netcoreapp3.1/publish`.
You can navigate to that folder and run `dotnet Web-Application-Development.dll` in order to test the executable  

## Exmaple Routes
- `http://localhost:80/students/1/` =>  serve students/1/index.html
- `http://localhost:80/students/1/` + `Accept: "text/plain"` =>  serve students/1/index.html

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
GET /students/ HTTP/1.1
Host: localhost
User-Agent: Mozilla/5.0
Accept: text/plain

```
4. Expect something like the following response:
```
HTTP/1.1 200 OK
Date: Tue, 03 Nov 2020 08:35:49 GMT
Content-Type: text/plain
Server: Kestrel
Content-Length: 835
Last-Modified: Tue, 03 Nov 2020 08:28:22 GMT
Accept-Ranges: bytes
ETag: "1d6b1bb4a721443"

Id: 1
Name: Simon Stratemeier
Studiengang: SEB
Fachsemester: 7
Profilbild: ../profilepicture.jpeg
GitLab Repo: https://git.it.hs-heilbronn.de/it/courses/seb/webdev/webdev-ws-2021/sstratem/minimalistischer-web-server
Zitat: Ich habe mich für Web Application Development (https://www.hs-heilbronn.de/webdev) entschieden weil ich evaluiere, ob ich eine Bachelor-Thesis beim Professor dieser Vorlesung durchführen möchte.

```

## Source code
You might be able to find the source code under <https://github.com/sstratemeier/Web-Application-Development/>
