FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["SMART_BIN.csproj", ""]
RUN dotnet restore "./SMART_BIN.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "SMART_BIN.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SMART_BIN.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SMART_BIN.dll"]