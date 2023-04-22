FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DemoApplication/SpaApp/SpaApp.csproj", "DemoApplication/SpaApp/"]
RUN dotnet restore "DemoApplication/SpaApp/SpaApp.csproj"
COPY . .
WORKDIR "/src/DemoApplication/SpaApp"
RUN dotnet build "SpaApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SpaApp.csproj" -c Release -o /app/publish

FROM nginx:alpine AS final
WORKDIR /usr/share/nginx/html
COPY ["DemoApplication/nginx.conf", "/etc/nginx/nginx.conf"]
COPY --from=publish /app/publish/wwwroot .