FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["prac6_1000.csproj", "prac6_1000/"]
RUN dotnet restore "prac6_1000/prac6_1000.csproj"

WORKDIR "/src/prac6_1000"
COPY . .
RUN dotnet build "prac6_1000.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prac6_1000.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prac6_1000.dll"]
