FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Ecommerce_PhuongNam.Shops/Ecommerce_PhuongNam.Shops.csproj", "src/Ecommerce_PhuongNam.Shops/"]
RUN dotnet restore "src/Ecommerce_PhuongNam.Shops/Ecommerce_PhuongNam.Shops.csproj"
COPY . .
WORKDIR "/src/src/Ecommerce_PhuongNam.Shops"
RUN dotnet build "Ecommerce_PhuongNam.Shops.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce_PhuongNam.Shops.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce_PhuongNam.Shops.dll"]
