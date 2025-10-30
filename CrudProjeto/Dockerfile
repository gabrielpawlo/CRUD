# Etapa 1: build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solução e os projetos
COPY *.sln .
COPY CrudProjeto/*.csproj CrudProjeto/

# Restaura as dependências
RUN dotnet restore CrudProjeto/CrudProjeto.csproj

# Copia tudo e compila
COPY . .
WORKDIR /src/CrudProjeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
EXPOSE 8080
ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
