FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY InnoShop.ProductsService.API/*.csproj InnoShop.ProductsService.API/
COPY InnoShop.ProductsService.Application/*.csproj InnoShop.ProductsService.Application/
COPY InnoShop.ProductsService.Infrastructure/*.csproj InnoShop.ProductsService.Infrastructure/
COPY InnoShop.ProductsService.Domain/*.csproj InnoShop.ProductsService.Domain/

RUN dotnet restore InnoShop.ProductsService.API/InnoShop.ProductsService.API.csproj

COPY . .
RUN dotnet publish InnoShop.ProductsService.API/InnoShop.ProductsService.API.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "InnoShop.ProductsService.API.dll"]
