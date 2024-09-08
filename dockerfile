FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet build
RUN dotnet publish -c Release
EXPOSE 8080
ENTRYPOINT ["dotnet", "UserRegistryApi/bin/Debug/net8.0/UserRegistryApi.dll"]