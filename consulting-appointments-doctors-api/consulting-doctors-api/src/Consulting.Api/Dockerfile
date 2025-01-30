#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/Consulting.Api/Consulting.Api.csproj", "src/Consulting.Api/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/ConsultingController/ConsultingController.csproj", "src/ConsultingController/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/ConsultingEntitys/ConsultingEntitys.csproj", "src/ConsultingEntitys/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/ConsultingInterface/ConsultingInterface.csproj", "src/ConsultingInterface/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/ConsultingUseCases/ConsultingUseCases.csproj", "src/ConsultingUseCases/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/Redis/Redis.csproj", "src/Redis/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/CacheGateway/CacheGateway.csproj", "src/CacheGateway/"]
COPY ["/consulting-appointments-doctors-api/consulting-doctors-api/src/DBGateways/DBGateways.csproj", "src/DBGateways/"]

RUN dotnet restore "./src/Consulting.Api/Consulting.Api.csproj"

COPY ["/consulting-appointments-doctors-api/consulting-doctors-api", "/src"]

WORKDIR "/src/src/Consulting.Api"
RUN dotnet build "Consulting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Consulting.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Consulting.Doctors.Api.dll"]