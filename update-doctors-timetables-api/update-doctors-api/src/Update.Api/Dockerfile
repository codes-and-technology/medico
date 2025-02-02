#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/update-doctors-timetables-api/update-doctors-api/src/Update.Api/Update.Api.csproj", "src/Update.Api/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/UpdateController/UpdateController.csproj", "src/UpdateController/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/UpdateEntitys/UpdateEntitys.csproj", "src/UpdateEntitys/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/UpdateInterface/UpdateInterface.csproj", "src/UpdateInterface/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/UpdateUseCases/UpdateUseCases.csproj", "src/UpdateUseCases/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/update-doctors-timetables-api/update-doctors-api/src/DBGateways/DBGateways.csproj", "src/DBGateways/"]

RUN dotnet restore "./src/Update.Api/Update.Api.csproj"

COPY ["/update-doctors-timetables-api/update-doctors-api", "/src"]

WORKDIR "/src/src/Update.Api"
RUN dotnet build "Update.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Update.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Update.Api.dll"]