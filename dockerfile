FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /src
COPY . .
RUN dotnet restore "./FridgeProducts/FridgeProducts.csproj"
RUN dotnet publish "./FridgeProducts/FridgeProducts.csproj" -c release -o /app

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app .

EXPOSE 80

ENTRYPOINT ["dotnet", "FridgeProducts.dll"]
