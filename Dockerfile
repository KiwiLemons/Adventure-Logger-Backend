FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

#ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_HTTP_PORTS=5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AdventureLoggerBackend.csproj", "."]
RUN dotnet restore "./AdventureLoggerBackend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "AdventureLoggerBackend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AdventureLoggerBackend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AdventureLoggerBackend.dll"]
