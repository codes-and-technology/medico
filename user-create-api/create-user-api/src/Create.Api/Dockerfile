#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["/user-create-api/create-user-api/src/Create.Api/Create.Api.csproj", "src/Create.Api/"]
COPY ["/user-create-api/create-user-api/src/CreateController/CreateController.csproj", "src/CreateController/"]
COPY ["/user-create-api/create-user-api/src/CreateEntitys/CreateEntitys.csproj", "src/CreateEntitys/"]
COPY ["/user-create-api/create-user-api/src/CreateInterface/CreateInterface.csproj", "src/CreateInterface/"]
COPY ["/user-create-api/create-user-api/src/CreateUseCases/CreateUseCases.csproj", "src/CreateUseCases/"]
COPY ["/user-create-api/create-user-api/src/Presenters/Presenters.csproj", "src/Presenters/"]

RUN dotnet restore "./src/Create.Api/Create.Api.csproj"

COPY ["/user-create-api/create-user-api", "/src"]

WORKDIR "/src/src/Create.Api"
RUN dotnet build "Create.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Create.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Create.Api.dll"]