# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos de solução e projeto
COPY *.sln .
COPY CrudProjeto/*.csproj CrudProjeto/

# Restaura dependências
RUN dotnet restore CrudProjeto/CrudProjeto.csproj

# Copia todo o restante do código
COPY . .

# Publica o projeto
WORKDIR /src/CrudProjeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: imagem final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Render define a porta automaticamente via variável de ambiente PORT
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 8080

ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
