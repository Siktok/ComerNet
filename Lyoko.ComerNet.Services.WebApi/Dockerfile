FROM  mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build-env
WORKDIR /src
COPY . .
WORKDIR /src/Lyoko.ComerNet.Services.WebApi
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0-nanoserver-1809
WORKDIR /app
COPY --from=build-env /src/Lyoko.ComerNet.Services.WebApi/out .

ENTRYPOINT ["dotnet", "Lyoko.ComerNet.Services.WebApi.dll"]
