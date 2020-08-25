FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
COPY ./ ./src
WORKDIR /src
RUN dotnet restore DataTransmission/DataTransmission.csproj
RUN dotnet restore CaroGame/CaroGame.csproj
RUN dotnet build DataTransmission/DataTransmission.csproj -c Release -o /app/build
RUN dotnet build CaroGame/CaroGame.csproj -c Release -o /app/build

FROM build AS publish
RUN dotnet publish DataTransmission/DataTransmission.csproj -c Release -o /app/publish
RUN dotnet publish CaroGame/CaroGame.csproj -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CaroGame.dll"]
