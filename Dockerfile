# ---- build ----
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY SpanishWebApi.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app/publish --no-restore

# ---- runtime ----
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV ASPNETCORE_HTTP_PORTS=8080 \
    ASPNETCORE_ENVIRONMENT=Production \
    ConnectionStrings__SpanishDb="Data Source=/app/Data/spanish.db;Mode=ReadOnly"

COPY --from=build /app/publish .
COPY --chown=app:app Data/spanish.db ./Data/spanish.db

USER app
EXPOSE 8080
ENTRYPOINT ["dotnet", "SpanishWebApi.dll"]