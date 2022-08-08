FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore

COPY . ./

RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"

RUN dotnet ef migrations bundle -o RecipeBundle.exe --project ./Recipe.Data.Entity.csproj

RUN echo "Server=${DATASOURCE};Database=${DATABASE};User Id=${USERID};Password=${PASSWORD}"
CMD ./RecipeBundle.exe --connection "Server=${DATASOURCE};Database=${DATABASE};User Id=${USERID};Password=${PASSWORD}"