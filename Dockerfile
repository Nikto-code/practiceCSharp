FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Pr_21/ShoppingListApp/ShoppingListApp.csproj", "Pr_21/ShoppingListApp/"]
RUN dotnet restore "Pr_21/ShoppingListApp/ShoppingListApp.csproj"
COPY . .
WORKDIR "/src/Pr_21/ShoppingListApp"
RUN dotnet build "ShoppingListApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ShoppingListApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ShoppingListApp.dll"]