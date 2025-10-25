# Etapa 1 — Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo e restaura dependências
COPY . .
RUN dotnet restore "./CrudProjeto.csproj"

# Publica o projeto
RUN dotnet publish "./CrudProjeto.csproj" -c Release -o /app/publish

# Etapa 2 — Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copia os arquivos publicados da etapa anterior
COPY --from=build /app/publish .

# Render define a porta em $PORT
ENV ASPNETCORE_URLS=http://*:$PORT

# Define o ponto de entrada
ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
