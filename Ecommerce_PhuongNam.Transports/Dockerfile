FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Ecommerce_PhuongNam..Transports/Ecommerce_PhuongNam..Transports.csproj", "Ecommerce_PhuongNam..Transports/"]
RUN dotnet restore "Ecommerce_PhuongNam..Transports/Ecommerce_PhuongNam..Transports.csproj"
COPY . .
WORKDIR "/src/Ecommerce_PhuongNam..Transports"
RUN dotnet build "Ecommerce_PhuongNam..Transports.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce_PhuongNam..Transports.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce_PhuongNam..Transports.dll"]
