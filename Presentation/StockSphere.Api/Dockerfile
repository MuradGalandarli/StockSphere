# Base image (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Projeleri kopyala
COPY ["Presentation/StockSphere.Api/StockSphere.Api.csproj", "Presentation/StockSphere.Api/"]
COPY ["Infrastructure/StockSphere.Infrastructure/StockSphere.Infrastructure.csproj", "Infrastructure/StockSphere.Infrastructure/"]
COPY ["Core/StockSphere.Application/StockSphere.Application.csproj", "Core/StockSphere.Application/"]
COPY ["Core/StockSphere.Domain/StockSphere.Domain.csproj", "Core/StockSphere.Domain/"]
COPY ["Infrastructure/StockSphere.Persistence/StockSphere.Persistence.csproj", "Infrastructure/StockSphere.Persistence/"]

# Restore dependencies
RUN dotnet restore "./Presentation/StockSphere.Api/StockSphere.Api.csproj"

# Layihəni konteynerə kopyala
COPY . .

WORKDIR "/src/Presentation/StockSphere.Api"

# Build
RUN dotnet build "./StockSphere.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./StockSphere.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Final stage (production / regular mode)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StockSphere.Api.dll"]
