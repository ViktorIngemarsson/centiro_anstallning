#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY ./Ingoing /app/Ingoing
COPY ./Ingoing/. /app/Ingoing/.
COPY ./Db /app/Db

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY centiro_anstallning.csproj ./
RUN dotnet restore "./centiro_anstallning.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "centiro_anstallning.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "centiro_anstallning.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "centiro_anstallning.dll"]
