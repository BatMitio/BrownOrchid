FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/BrownOrchid.Services.BankEmployees/BrownOrchid.Services.BankEmployees.Worker/BrownOrchid.Services.BankEmployees.Worker.csproj", "BrownOrchid.Services.BankEmployees.Worker/"]
RUN dotnet restore "src/Services/BrownOrchid.Services.BankEmployees/BrownOrchid.Services.BankEmployees.Worker/BrownOrchid.Services.BankEmployees.Worker.csproj"
COPY . .
WORKDIR "/src/BrownOrchid.Services.BankEmployees.Worker"
RUN dotnet build "BrownOrchid.Services.BankEmployees.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BrownOrchid.Services.BankEmployees.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BrownOrchid.Services.BankEmployees.Worker.dll"]
