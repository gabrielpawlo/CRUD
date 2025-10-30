# Etapa 1: build da aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo de projeto e restaura dependências
COPY *.csproj .
RUN dotnet restore

# Copia o restante do código e faz o build + publish
COPY . .
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: imagem final (runtime)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Render define a variável de ambiente PORT
ENV ASPNETCORE_URLS=http://+:${PORT}
EXPOSE 8080

ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
