# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files
COPY ["/notification-worker/src/Notification.Worker/Notification.Worker.csproj", "src/Notification.Worker/"]
COPY ["/notification-worker/src/Controllers/Controllers.csproj", "src/Controllers/"]
COPY ["/notification-worker/src/Entitys/Entitys.csproj", "src/Entitys/"]
COPY ["/notification-worker/src/Interfaces/Interfaces.csproj", "src/Interfaces/"]
COPY ["/notification-worker/src/Presenters/Presenters.csproj", "src/Presenters/"]
COPY ["/notification-worker/src/UseCases/UseCases.csproj", "src/UseCases/"]
COPY ["/notification-worker/src/DataBase/DataBase.csproj", "src/DataBase/"]
COPY ["/notification-worker/src/Gateways/Gateways.csproj", "src/Gateways/"]
COPY ["/notification-worker/src/MailKit.Email/MailKit.Email.csproj", "src/MailKit.Email/"]
COPY ["/notification-worker/src/Rabbit.Consumer/Rabbit.Consumer.csproj", "src/Rabbit.Consumer/"]

# Restore dependencies
RUN dotnet restore "./src/Notification.Worker/Notification.Worker.csproj"

# Copy the rest of the source code
COPY ["/notification-worker", "/src"]

# Build the application
WORKDIR "/src/src/Notification.Worker"
RUN dotnet build "./Notification.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "./Notification.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage - use the ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Notification.Worker.dll"]