#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/create-doctors-timetables-api/create-doctors-api/src/Create.Api/Create.Api.csproj", "src/Create.Api/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/CreateController/CreateController.csproj", "src/CreateController/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/CreateEntitys/CreateEntitys.csproj", "src/CreateEntitys/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/CreateInterface/CreateInterface.csproj", "src/CreateInterface/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/CreateUseCases/CreateUseCases.csproj", "src/CreateUseCases/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/Redis/Redis.csproj", "src/Redis/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/CacheGateway/CacheGateway.csproj", "src/CacheGateway/"]
COPY ["/create-doctors-timetables-api/create-doctors-api/src/DBGateways/DBGateways.csproj", "src/DBGateways/"]

RUN dotnet restore "./src/Create.Api/Create.Api.csproj"

COPY ["/create-doctors-timetables-api/create-doctors-api", "/src"]

WORKDIR "/src/src/Create.Api"
RUN dotnet build "Create.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Create.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Create.Api.dll"]