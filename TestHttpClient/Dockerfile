#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0-preview AS base
WORKDIR /app
ENV ASPNETCORE_HTTP_PORTS 8000

FROM mcr.microsoft.com/dotnet/sdk:8.0-preview AS build
WORKDIR /src
COPY ["TestHttpClient/TestHttpClient.csproj", "TestHttpClient/"]
RUN dotnet restore "TestHttpClient/TestHttpClient.csproj"
COPY . .
WORKDIR "/src/TestHttpClient"
RUN dotnet build "TestHttpClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestHttpClient.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestHttpClient.dll"]