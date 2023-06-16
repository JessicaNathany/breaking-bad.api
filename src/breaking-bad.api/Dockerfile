#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/breaking-bad.api/breaking-bad.api.csproj", "src/breaking-bad.api/"]
RUN dotnet restore "src/breaking-bad.api/breaking-bad.api.csproj"
COPY . .
WORKDIR "/src/src/breaking-bad.api"
RUN dotnet build "breaking-bad.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "breaking-bad.api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "breaking-bad.api.dll"]