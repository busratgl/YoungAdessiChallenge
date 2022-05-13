FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["YoungAdessiChallengeProject.API/YoungAdessiChallengeProject.API.csproj", "YoungAdessiChallengeProject.API/"]
RUN dotnet restore "YoungAdessiChallengeProject.API/YoungAdessiChallengeProject.API.csproj"
COPY . .
WORKDIR "/src/YoungAdessiChallengeProject.API"
RUN dotnet build "YoungAdessiChallengeProject.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YoungAdessiChallengeProject.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YoungAdessiChallengeProject.API.dll"]
