FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.BankEmployees/BrownOrchid.Services.BankEmployees.Api/BrownOrchid.Services.BankEmployees.Api.csproj", "BrownOrchid.Services.BankEmployees.Api/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.BankEmployees/BrownOrchid.Services.BankEmployees.Api/BrownOrchid.Services.BankEmployees.Api.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.BankEmployees.Api"
RUN dotnet build "BrownOrchid.Services.BankEmployees.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.BankEmployees.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.BankEmployees.Api.dll"]
