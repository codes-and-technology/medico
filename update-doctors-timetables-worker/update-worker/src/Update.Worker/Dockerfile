#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["/update-doctors-timetables-worker/update-worker/src/Update.Worker/Update.Worker.csproj", "src/Update.Worker/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/UpdateController/UpdateController.csproj", "src/UpdateController/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/UpdateEntitys/UpdateEntitys.csproj", "src/UpdateEntitys/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/UpdateInterface/UpdateInterface.csproj", "src/UpdateInterface/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/UpdateUseCases/UpdateUseCases.csproj", "src/UpdateUseCases/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/update-doctors-timetables-worker/update-worker/src/Rabbit.Consumer.Update/Rabbit.Consumer.Update.csproj", "src/Rabbit.Consumer.Update/"]

RUN dotnet restore	 "./src/Update.Worker/Update.Worker.csproj"

COPY ["/update-doctors-timetables-worker/update-worker", "/src"]

WORKDIR "/src/src/Update.Worker"
RUN dotnet build "./Update.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Update.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Update.Worker.dll"]