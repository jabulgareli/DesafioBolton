FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Bolton/DesafioBolton.Bolton.API/DesafioBolton.Bolton.API.csproj", "src/Bolton/DesafioBolton.Bolton.API/"]
RUN dotnet restore "src/Bolton/DesafioBolton.Bolton.API/DesafioBolton.Bolton.API.csproj"
COPY . .
WORKDIR "/src/src/Bolton/DesafioBolton.Bolton.API"
RUN dotnet build "DesafioBolton.Bolton.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioBolton.Bolton.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioBolton.Bolton.API.dll"]