#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["AzureDevOps.API/AzureDevOps.API.csproj", "AzureDevOps.API/"]
COPY ["AzureDevOps.Domain/AzureDevOps.Domain.csproj", "AzureDevOps.Domain/"]
COPY ["AzureDevOps.Services/AzureDevOps.Services.csproj", "AzureDevOps.Services/"]
COPY ["AzureDevOps.Repositories/AzureDevOps.Repositories.csproj", "AzureDevOps.Repositories/"]
RUN dotnet restore "AzureDevOps.API/AzureDevOps.API.csproj"
COPY . .
WORKDIR "/src/AzureDevOps.API"
RUN dotnet build "AzureDevOps.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AzureDevOps.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AzureDevOps.API.dll"]