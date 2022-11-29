#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Copy csproj and restore as distinct layers
COPY ["Techo.API/Techo.API.csproj", "Techo.API/"]
COPY ["Techo.Core.Contracts/Techo.Core.Contracts.csproj", "Techo.Core.Contracts/"]
COPY ["Techo.Models/Techo.Models.csproj", "Techo.Models/"]
COPY ["Techo.Data/Techo.Data.csproj", "Techo.Data/"]
COPY ["Techo.Core/Techo.Core.csproj", "Techo.Core/"]
COPY *.sln .
RUN dotnet restore "Techo.API/Techo.API.csproj"

# Copy everything else and build
COPY . .
RUN dotnet publish -c Release -o build -no-restore

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY -from=build-env /build .
ENV ASPNETCORE_URL=http://*:8080
EXPOSE 8080
ENTRYPOINT ["dotnet", "Techo.API.dll"]