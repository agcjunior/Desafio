# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Desafio.Api/Desafio.Api.csproj", "Desafio.Api/"]
COPY ["Desafio.Applicacao/Desafio.Aplicacao.csproj", "Desafio.Applicacao/"]
COPY ["Desafio.Comum/Desafio.Comum.csproj", "Desafio.Comum/"]
COPY ["Desafio.Dominio/Desafio.Dominio.csproj", "Desafio.Dominio/"]
COPY ["Desafio.Infraestrutura/Desafio.Infraestrutura.csproj", "Desafio.Infraestrutura/"]
RUN dotnet restore "./Desafio.Api/Desafio.Api.csproj"
COPY . .
WORKDIR "/src/Desafio.Api"
RUN dotnet build "./Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Desafio.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Desafio.Api.dll"]