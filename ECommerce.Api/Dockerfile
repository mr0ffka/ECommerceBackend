#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER root
WORKDIR /app
EXPOSE 8080
#EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ECommerce.Api/ECommerce.Api.csproj", "ECommerce.Api/"]
COPY ["ECommerce.Application/ECommerce.Application.csproj", "ECommerce.Application/"]
COPY ["ECommerce.Domain/ECommerce.Domain.csproj", "ECommerce.Domain/"]
COPY ["ECommerce.Identity/ECommerce.Identity.csproj", "ECommerce.Identity/"]
COPY ["ECommerce.Infrastructure/ECommerce.Infrastructure.csproj", "ECommerce.Infrastructure/"]
COPY ["ECommerce.Persistence/ECommerce.Persistence.csproj", "ECommerce.Persistence/"]
RUN dotnet restore "./ECommerce.Api/./ECommerce.Api.csproj"
COPY . .
WORKDIR "/src/ECommerce.Api"
RUN dotnet build "./ECommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build
#RUN dotnet ef database update

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ECommerce.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
#RUN chmod -R 777 /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=""
ENTRYPOINT ["dotnet", "ECommerce.Api.dll"]