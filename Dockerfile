# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj files and restore
COPY LearnDockerCiCd.Api/*.csproj LearnDockerCiCd.Api/
COPY LearnDockerCiCd.Domain/*.csproj LearnDockerCiCd.Domain/
COPY LearnDockerCiCd.Application/*.csproj LearnDockerCiCd.Application/
COPY LearnDockerCiCd.Infrastructure/*.csproj LearnDockerCiCd.Infrastructure/

# Restore the main API project
RUN dotnet restore LearnDockerCiCd.Api/LearnDockerCiCd.Api.csproj

# Copy everything else
COPY . .

# Publish the API project
RUN dotnet publish LearnDockerCiCd.Api/LearnDockerCiCd.Api.csproj -c Release -o /app/out

# Runtime Stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

# Listen on 8080
EXPOSE 8080

# Listen on port 8085
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "LearnDockerCiCd.Api.dll"]
