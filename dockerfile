FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY . .
RUN dotnet publish -c Release
EXPOSE 7069
ENTRYPOINT ["dotnet", "UserRegistryApi/bin/Debug/net8.0/UserRegistryApi.dll"]