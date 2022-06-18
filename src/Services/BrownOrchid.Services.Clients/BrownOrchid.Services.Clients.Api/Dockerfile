FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.Clients/BrownOrchid.Services.Clients.Api/BrownOrchid.Services.Clients.Api.csproj", "BrownOrchid.Services.Clients.Api/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.Clients/BrownOrchid.Services.Clients.Api/BrownOrchid.Services.Clients.Api.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.Clients.Api"
RUN dotnet build "BrownOrchid.Services.Clients.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.Clients.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.Clients.Api.dll"]
