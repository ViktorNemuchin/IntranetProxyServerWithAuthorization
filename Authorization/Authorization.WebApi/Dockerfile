FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Authorization.WebApi/Authorization.WebApi.csproj", "Authorization.WebApi/"]
COPY ["UserRepository/Repositories.UserRepository.csproj", "UserRepository/"]
COPY ["../NetCore.Core.Configuration/Core.Configuration.csproj", "../NetCore.Core.Configuration/"]
COPY ["../NetCore.Core.Data/Core.Data.csproj", "../NetCore.Core.Data/"]
COPY ["../Db.Authorization/Db.Authorization.csproj", "../Db.Authorization/"]
RUN dotnet restore "Authorization.WebApi/Authorization.WebApi.csproj"
COPY . .
WORKDIR "/src/Authorization.WebApi"
RUN dotnet build "Authorization.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Authorization.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Authorization.WebApi.dll"]