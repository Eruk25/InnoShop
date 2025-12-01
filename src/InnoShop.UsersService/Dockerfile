FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

COPY InnoShop.UsersService.API/*.csproj InnoShop.UsersService.API/
COPY InnoShop.UsersService.Application/*.csproj InnoShop.UsersService.Application/
COPY InnoShop.UsersService.Infrastructure/*.csproj InnoShop.UsersService.Infrastructure/
COPY InnoShop.UsersService.Domain/*.csproj InnoShop.UsersService.Domain/

RUN dotnet restore InnoShop.UsersService.API/InnoShop.UsersService.API.csproj

COPY . .
RUN dotnet publish InnoShop.UsersService.API/InnoShop.UsersService.API.csproj -c Release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /app
COPY --from=build /app .

ENTRYPOINT ["dotnet", "InnoShop.UsersService.API.dll"]
