FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["FamTree.Cofoundry.WebApp/FamTree.Cofoundry.WebApp.csproj", "FamTree.Cofoundry.WebApp/"]
RUN dotnet restore "FamTree.Cofoundry.WebApp/FamTree.Cofoundry.WebApp.csproj"
COPY . .
WORKDIR "/src/FamTree.Cofoundry.WebApp"
RUN dotnet build "FamTree.Cofoundry.WebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "FamTree.Cofoundry.WebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FamTree.Cofoundry.WebApp.dll"]
