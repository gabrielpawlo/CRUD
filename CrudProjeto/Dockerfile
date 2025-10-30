# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia a solução e restaura dependências
COPY *.sln .
COPY CrudProjeto/*.csproj CrudProjeto/
RUN dotnet restore CrudProjeto/CrudProjeto.csproj

# Copia todo o código e compila
COPY . .
WORKDIR /src/CrudProjeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: runtime da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render usa a variável PORT automaticamente
ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE 8080

ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
