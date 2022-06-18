FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Gateways/BrownOrchid.Gateways.App/BrownOrchid.Gateways.App.csproj", "BrownOrchid.Gateways.App/"]
RUN dotnet restore "src/Gateways/BrownOrchid.Gateways.App/BrownOrchid.Gateways.App.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Gateways.App"
RUN dotnet build "BrownOrchid.Gateways.App.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Gateways.App.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Gateways.App.dll"]
