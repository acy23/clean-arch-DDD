FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY karavana_API.sln ./
COPY karavana_API/*.csproj ./karavana_API/
COPY karavana_APPLICATION/*.csproj ./karavana_APPLICATION/
COPY karavana_CONTRACTS/*.csproj ./karavana_CONTRACTS/
COPY karavana_DOMAIN/*.csproj ./karavana_DOMAIN/
COPY karavana_INFRASTRUCTURE/*.csproj ./karavana_INFRASTRUCTURE/

RUN dotnet restore
COPY . .

WORKDIR /src/karavana_API
RUN dotnet build -c Release -o /app

WORKDIR /src/karavana_APPLICATION
RUN dotnet build -c Release -o /app

WORKDIR /src/karavana_CONTRACTS
RUN dotnet build -c Release -o /app

WORKDIR /src/karavana_DOMAIN
RUN dotnet build -c Release -o /app

WORKDIR /src/karavana_INFRASTRUCTURE
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "karavana_API.dll"]