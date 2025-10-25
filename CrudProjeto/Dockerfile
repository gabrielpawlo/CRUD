# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY *.sln .
COPY CrudProjeto/*.csproj CrudProjeto/
RUN dotnet restore CrudProjeto/CrudProjeto.csproj
COPY . .
WORKDIR /src/CrudProjeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
