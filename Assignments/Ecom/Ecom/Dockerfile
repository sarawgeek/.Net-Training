FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY *.csproj ./

RUN dotnet restore

COPY . ./

RUN dotnet build "Ecom.csproj" -c Release -o /app/build

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app

COPY --from=build-env /app/out .

EXPOSE 80

EXPOSE 443

ENTRYPOINT [ "dotnet","Ecom.dll" ]