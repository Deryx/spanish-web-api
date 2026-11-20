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
    ConnectionStrings__SpanishDb="Data Source=/data/spanish.db"

# database lives in a volume, not in the image
RUN mkdir /data && chown app:app /data

COPY --from=build /app/publish .

USER app
EXPOSE 8080
VOLUME /data
ENTRYPOINT ["dotnet", "SpanishWebApi.dll"]