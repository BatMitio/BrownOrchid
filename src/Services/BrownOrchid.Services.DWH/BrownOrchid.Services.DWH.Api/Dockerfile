FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.DWH/BrownOrchid.Services.DWH.Api/BrownOrchid.Services.DWH.Api.csproj", "BrownOrchid.Services.DWH.Api/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.DWH/BrownOrchid.Services.DWH.Api/BrownOrchid.Services.DWH.Api.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.DWH.Api"
RUN dotnet build "BrownOrchid.Services.DWH.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.DWH.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.DWH.Api.dll"]
