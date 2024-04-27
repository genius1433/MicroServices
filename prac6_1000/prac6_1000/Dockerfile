#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["prac6_1000/prac6_1000.csproj", "prac6_1000/"]
RUN dotnet restore "prac6_1000/prac6_1000.csproj"
COPY . .
WORKDIR "/src/prac6_1000"
RUN dotnet build "prac6_1000.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "prac6_1000.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "prac6_1000.dll"]