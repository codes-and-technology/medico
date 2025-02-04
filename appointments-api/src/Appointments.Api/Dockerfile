#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/appointments-api/src/Appointments.Api/Appointments.Api.csproj", "src/Appointments.Api/"]
COPY ["/appointments-api/src/Controllers/Controllers.csproj", "src/Controllers/"]
COPY ["/appointments-api/src/Entitys/Entitys.csproj", "src/Entitys/"]
COPY ["/appointments-api/src/Interfaces/Interfaces.csproj", "src/Interfaces/"]
COPY ["/appointments-api/src/UseCases/UseCases.csproj", "src/UseCases/"]
COPY ["/appointments-api/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/appointments-api/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/appointments-api/src/Redis/Redis.csproj", "src/Redis/"]
COPY ["/appointments-api/src/CacheGateway/CacheGateway.csproj", "src/CacheGateway/"]
COPY ["/appointments-api/src/DBGateways/DBGateways.csproj", "src/DBGateways/"]

RUN dotnet restore "./src/Appointments.Api/Appointments.Api.csproj"

COPY ["/appointments-api", "/src"]

WORKDIR "/src/src/Appointments.Api"
RUN dotnet build "Appointments.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Appointments.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Appointments.Api.dll"]