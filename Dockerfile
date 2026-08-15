FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Ella .csproj file um copy pannu
COPY *.csproj .
RUN dotnet restore

# Motha code um copy pannu
COPY . 
RUN dotnet publish "EmpManager.csproj" -c Release -o /app/out

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "EmpManager.dll"]
