FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 4000
EXPOSE 27017

ENV ASPNETCORE_URLS=http://+:4000

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CarrierPidgeon.csproj", "./"]
RUN dotnet restore "CarrierPidgeon.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "CarrierPidgeon.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CarrierPidgeon.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY ./Properties /app/Properties
ENTRYPOINT ["dotnet", "CarrierPidgeon.dll"]
