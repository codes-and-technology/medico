#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Create.Worker/Create.Worker.csproj", "Create.Worker/"]
COPY ["src/CreateController/CreateController.csproj", "CreateController/"]
COPY ["src/CreateEntitys/CreateEntitys.csproj", "CreateEntitys/"]
COPY ["src/CreateInterface/CreateInterface.csproj", "CreateInterface/"]
COPY ["src/Presenters/Presenters.csproj", "Presenters/"]
COPY ["src/CreateUseCases/CreateUseCases.csproj", "CreateUseCases/"]
COPY ["src/DataBase/DataBase.csproj", "DataBase/"]
COPY ["src/Rabbit.Consumer.Create/Rabbit.Consumer.Create.csproj", "Rabbit.Consumer.Create/"]

RUN dotnet restore "./src/Create.Worker/Create.Worker.csproj"

COPY ["/create-worker", "/src"]

WORKDIR "/src/Create.Worker"
RUN dotnet build "./Create.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Create.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Create.Worker.dll"]