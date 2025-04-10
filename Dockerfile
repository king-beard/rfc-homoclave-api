FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /App

COPY . .
RUN cd RfcHomoclave.API
RUN dotnet restore --disable-parallel
RUN dotnet publish -c Release -o out --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build-env /App/out .

EXPOSE 80
ENV ASPNETCORE_HTTP_PORTS=80

ENTRYPOINT ["dotnet", "RfcHomoclave.API.dll"]
