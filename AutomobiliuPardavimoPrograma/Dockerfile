
# 1) Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet publish "AutomobiliuPardavimoPrograma.csproj" \
    -c Release -o /app/publish

# 2) Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish ./

# Tell ASP.NET Core to listen on 0.0.0.0:8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

EXPOSE 8080

# Run your app
ENTRYPOINT ["dotnet", "AutomobiliuPardavimoPrograma.dll"]

