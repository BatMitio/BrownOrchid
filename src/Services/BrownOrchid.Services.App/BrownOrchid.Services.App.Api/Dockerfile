FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.App/BrownOrchid.Services.App.Api/BrownOrchid.Services.App.Api.csproj", "BrownOrchid.Services.App.Api/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.App/BrownOrchid.Services.App.Api/BrownOrchid.Services.App.Api.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.App.Api"
RUN dotnet build "BrownOrchid.Services.App.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.App.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.App.Api.dll"]
