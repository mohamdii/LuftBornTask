# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# Copy csproj files first so Docker can cache the restore layer
# (only re-runs restore if a .csproj actually changes, not on every code edit)
COPY LuftBornTask.sln .
COPY src/LuftBornTask.Domain/*.csproj src/LuftBornTask.Domain/
COPY src/LuftBornTask.Application/*.csproj src/LuftBornTask.Application/
COPY src/LuftBornTask.Infrastructure/*.csproj src/LuftBornTask.Infrastructure/
COPY src/LuftBornTask.Api/*.csproj src/LuftBornTask.Api/

RUN dotnet restore src/LuftBornTask.Api/LuftBornTask.Api.csproj

# Now copy everything else and publish
COPY src/ src/
RUN dotnet publish src/LuftBornTask.Api/LuftBornTask.Api.csproj \
    -c Release \
    -o /app/publish \
    --no-restore

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

# SQLite file needs to persist outside the container's writable layer
VOLUME ["/app/data"]

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "LuftBornTask.Api.dll"]