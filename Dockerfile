FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["Pr_21/ShoppingListApp/ShoppingListApp.csproj", "Pr_21/ShoppingListApp/"]
RUN dotnet restore "Pr_21/ShoppingListApp/ShoppingListApp.csproj"
COPY . .
WORKDIR "/src/Pr_21/ShoppingListApp"
RUN dotnet publish "ShoppingListApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "ShoppingListApp.dll"]
