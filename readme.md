## Commands
- docker ps //List containers
- docker run -p 5672:5672 rabbitmq
- docker run -d -p 27017:27017 mongo
- docker stop [containerid]
- src\Actio.Api> dotnet run
- src\Actio.Services.Activities> dotnet run --urls "http://*:5050"
- src\Actio.Services.Identity> dotnet run --urls "http://*:5051"