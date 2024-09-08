FROM mcr.microsoft.com/dotnet/sdk:8.0
WORKDIR /app
COPY *.csproj ./
RUN dotnet restore
COPY . .
RUN dotnet publish -c Release -o /app
EXPOSE 7069
ENTRYPOINT ["dotnet", "YourProjectName.dll"]