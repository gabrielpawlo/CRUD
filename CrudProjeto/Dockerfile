# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia os arquivos da solução e do projeto
COPY CrudSolucao.sln ./
COPY CrudProjeto/CrudProjeto.csproj CrudProjeto/
RUN dotnet restore CrudProjeto/CrudProjeto.csproj

# Copia o resto do código e faz o build
COPY . .
WORKDIR /src/CrudProjeto
RUN dotnet publish -c Release -o /app/publish

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Importante: usar a variável de porta do Render
ENV ASPNETCORE_URLS=http://+:$PORT
ENTRYPOINT ["dotnet", "CrudProjeto.dll"]
