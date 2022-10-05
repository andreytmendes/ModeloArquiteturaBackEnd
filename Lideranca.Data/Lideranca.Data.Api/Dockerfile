#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Lideranca.Data.Api/Lideranca.Data.Api.csproj", "Lideranca.Data.Api/"]
RUN dotnet restore "Lideranca.Data.Api/Lideranca.Data.Api.csproj"
COPY . .
WORKDIR "/src/Lideranca.Data.Api"
RUN dotnet build "Lideranca.Data.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Lideranca.Data.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lideranca.Data.Api.dll"]