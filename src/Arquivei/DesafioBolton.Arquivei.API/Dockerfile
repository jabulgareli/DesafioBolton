FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Arquivei/DesafioBolton.Arquivei.API/DesafioBolton.Arquivei.API.csproj", "src/Arquivei/DesafioBolton.Arquivei.API/"]
RUN dotnet restore "src/Arquivei/DesafioBolton.Arquivei.API/DesafioBolton.Arquivei.API.csproj"
COPY . .
WORKDIR "/src/src/Arquivei/DesafioBolton.Arquivei.API"
RUN dotnet build "DesafioBolton.Arquivei.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DesafioBolton.Arquivei.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DesafioBolton.Arquivei.API.dll"]