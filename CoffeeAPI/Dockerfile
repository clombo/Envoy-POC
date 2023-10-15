FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY [".", "CoffeeAPI/"]
RUN dotnet restore "CoffeeAPI/Coffee.API/Coffee.API.csproj"
COPY . .
WORKDIR "/src/CoffeeAPI"
RUN dotnet build "Coffee.API/Coffee.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Coffee.API/Coffee.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Coffee.API.dll"]
