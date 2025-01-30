#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/auth-api/auth-api/src/Auth.Api/Auth.Api.csproj", "src/Auth.Api/"]
COPY ["/auth-api/auth-api/src/AuthController/AuthController.csproj", "src/AuthController/"]
COPY ["/auth-api/auth-api/src/AuthEntitys/AuthEntitys.csproj", "src/AuthEntitys/"]
COPY ["/auth-api/auth-api/src/AuthInterface/AuthInterface.csproj", "src/AuthInterface/"]
COPY ["/auth-api/auth-api/src/AuthUseCases/AuthUseCases.csproj", "src/AuthUseCases/"]
COPY ["/auth-api/auth-api/src/Presenters/Presenters.csproj", "src/Presenters/"]

RUN dotnet restore "./src/Auth.Api/Auth.Api.csproj"

COPY ["/auth-api/auth-api", "/src"]

WORKDIR "/src/src/Auth.Api"
RUN dotnet build "Auth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Auth.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Auth.Api.dll"]