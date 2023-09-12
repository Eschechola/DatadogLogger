FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build-env

WORKDIR /logger
COPY [".", "Logger/"]

RUN dotnet restore "Logger/Logger.csproj"
RUN dotnet build "Logger/Logger.csproj"
RUN dotnet publish "Logger/Logger.csproj" -c Release -o publish

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS runtime
WORKDIR /app
COPY --from=build-env /logger/publish .

#datadog agent needs
RUN apk --no-cache add musl

ENTRYPOINT ["dotnet", "Logger.dll"]