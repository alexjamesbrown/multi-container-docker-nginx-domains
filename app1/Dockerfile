#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["app1/app1.csproj", "app1/"]
RUN dotnet restore "app1/app1.csproj"
COPY . .
WORKDIR "/src/app1"
RUN dotnet build "app1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "app1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "app1.dll"]
