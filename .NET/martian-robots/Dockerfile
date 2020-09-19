FROM mcr.microsoft.com/dotnet/core/sdk:3.1 as build-env
WORKDIR /app
COPY . .
WORKDIR /app/Kifreak.MartianRobots.Console
RUN dotnet restore
RUN dotnet publish -c Release -o out
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app/Kifreak.MartianRobots.Console
COPY --from=build-env /app/Kifreak.MartianRobots.Console/out .
ENTRYPOINT ["dotnet", "Kifreak.MartianRobots.Console.dll"]