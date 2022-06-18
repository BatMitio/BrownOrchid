FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.App/BrownOrchid.Services.App.Worker/BrownOrchid.Services.App.Worker.csproj", "BrownOrchid.Services.App.Worker/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.App/BrownOrchid.Services.App.Worker/BrownOrchid.Services.App.Worker.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.App.Worker"
RUN dotnet build "BrownOrchid.Services.App.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.App.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.App.Worker.dll"]
