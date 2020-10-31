#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

ARG  MACHINE_ARCH
FROM mcr.microsoft.com/dotnet/core/runtime:3.1-buster-slim${MACHINE_ARCH} AS base
WORKDIR /app

RUN apt update && apt install -y \
        jq \
        mosquitto-clients

ARG  MACHINE_ARCH
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster${MACHINE_ARCH} AS build
WORKDIR /src
COPY ["src/inverter/inverter.csproj", "src/inverter/"]
RUN dotnet restore "src/inverter/inverter.csproj"
COPY . .
WORKDIR "/src/src/inverter"
RUN dotnet build "inverter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "inverter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "inverter.dll"]
