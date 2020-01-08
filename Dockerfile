FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
COPY . .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet SMART_BIN.dll