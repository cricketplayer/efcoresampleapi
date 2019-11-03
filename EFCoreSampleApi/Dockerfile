FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["EFCoreSampleApi/EFCoreSampleApi.csproj", "EFCoreSampleApi/"]
RUN dotnet restore "EFCoreSampleApi/EFCoreSampleApi.csproj"
COPY . .
WORKDIR "/src/EFCoreSampleApi"
RUN dotnet build "EFCoreSampleApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EFCoreSampleApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EFCoreSampleApi.dll"]