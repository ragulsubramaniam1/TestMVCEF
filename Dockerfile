# Use the official ASP.NET Core runtime as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy the project file(s) and restore dependencies
COPY ["TestMVCEF.csproj", "./"]
RUN dotnet restore "TestMVCEF.csproj"

# copy everything else and build
COPY . .
WORKDIR "/src"
RUN dotnet publish "TestMVCEF.csproj" -c Release -o /app/publish

# final stage
FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "TestMVCEF.dll"]
