# Usar la imagen base de .NET SDK para construir la aplicación
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copiar el archivo .csproj y restaurar las dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto del código y construir la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Usar la imagen base de .NET Runtime para ejecutar la aplicación
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

# Exponer el puerto que usará la aplicación
EXPOSE 5244

# Comando para ejecutar la aplicación
ENTRYPOINT ["dotnet", "ApiRestFull.dll"]