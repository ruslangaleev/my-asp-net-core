#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["MyCore.API/MyCore.API.csproj", "MyCore.API/"]
RUN dotnet restore "MyCore.API/MyCore.API.csproj"
COPY . .
WORKDIR "/src/MyCore.API"
RUN dotnet build "MyCore.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyCore.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyCore.API.dll"]