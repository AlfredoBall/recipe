FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

ENV API=./Services/API/Recipe.API

COPY $API/*.csproj ./
COPY $API/nuget.config ./
RUN dotnet restore

COPY $API ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app

EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

COPY --from=build-env /app/out .

ENTRYPOINT [ "dotnet", "Recipe.API.dll"]