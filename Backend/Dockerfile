FROM mcr.microsoft.com/dotnet/sdk:7.0 as base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /source
COPY ["src/WoofLodge.Api/WoofLodge.Api.csproj", "WoofLodge.Api/"]
RUN dotnet restore "WoofLodge.Api/WoofLodge.Api.csproj"
COPY . .
WORKDIR "/source/src/WoofLodge.Api"
RUN dotnet build "WoofLodge.Api.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "WoofLodge.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM build AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WoofLodge.Api.dll"]
