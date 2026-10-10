# ===== ЭТАП 1: СБОРКА =====
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

COPY ["HospitalWeb.csproj", "./"]
RUN dotnet restore "HospitalWeb.csproj"

COPY . .
RUN dotnet publish "HospitalWeb.csproj" -c Release -o /app/publish

# ===== ЭТАП 2: ЗАПУСК =====
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app

COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000

ENTRYPOINT ["dotnet", "HospitalWeb.dll"]