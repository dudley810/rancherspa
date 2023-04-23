FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SpaApp/SpaApp.csproj", "SpaApp/"]
RUN dotnet restore "src/SpaApp/SpaApp.csproj"
COPY . .
WORKDIR "/src/SpaApp"
RUN dotnet build "SpaApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaApp.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY ["yaml/nginx.conf", "/etc/nginx/nginx.conf"]
COPY --from=publish /app/publish/wwwroot .