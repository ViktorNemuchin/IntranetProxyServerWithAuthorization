FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["WebApiRouter/WebApiRouter.csproj", "WebApiRouter/"]
COPY ["UserRightsValidation/UserRightsValidation.csproj", "UserRightsValidation/"]
COPY ["UserRepository/Repositories.UserRepository.csproj", "UserRepository/"]
COPY ["../NetCore.Core.Configuration/Core.Configuration.csproj", "../NetCore.Core.Configuration/"]
COPY ["../NetCore.Core.Data/Core.Data.csproj", "../NetCore.Core.Data/"]
COPY ["../Db.Authorization/Db.Authorization.csproj", "../Db.Authorization/"]
COPY ["Authorization.WebApi/Authorization.WebApi.csproj", "Authorization.WebApi/"]
RUN dotnet restore "WebApiRouter/WebApiRouter.csproj"
COPY . .
WORKDIR "/src/WebApiRouter"
RUN dotnet build "WebApiRouter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApiRouter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApiRouter.dll"]