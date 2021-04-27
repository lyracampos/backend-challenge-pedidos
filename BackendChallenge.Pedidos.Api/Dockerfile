FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80  
EXPOSE 443 

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["BackendChallenge.Pedidos.Api/BackendChallenge.Pedidos.Api.csproj", "BackendChallenge.Pedidos.Api/"]
COPY ["BackendChallenge.Pedidos.Application/BackendChallenge.Pedidos.Application.csproj", "BackendChallenge.Pedidos.Application/"]
COPY ["BackendChallenge.Pedidos.Domain/BackendChallenge.Pedidos.Domain.csproj", "BackendChallenge.Pedidos.Domain/"]
COPY ["BackendChallenge.Pedidos.Infrastructure/BackendChallenge.Pedidos.Infrastructure.csproj", "BackendChallenge.Pedidos.Infrastructure/"]
RUN dotnet restore "BackendChallenge.Pedidos.Api/BackendChallenge.Pedidos.Api.csproj"
COPY . .
WORKDIR "/src/BackendChallenge.Pedidos.Api"
RUN dotnet build "BackendChallenge.Pedidos.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "BackendChallenge.Pedidos.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackendChallenge.Pedidos.Api.dll"]