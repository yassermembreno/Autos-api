FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY autos-api.sln ./
COPY autos-api/AutosApi.csproj ./autos-api/
COPY Domain/Domain.csproj ./Domain/
COPY Infraestructure/Infraestructure.csproj ./Infraestructure/
COPY Application/Application.csproj ./Application/
COPY Test/Test.csproj ./Test/

RUN dotnet restore

COPY autos-api/. ./autos-api/
COPY Domain/. ./Domain/
COPY Infraestructure/. ./Infraestructure/
COPY Application/. ./Application/

WORKDIR /src
RUN dotnet publish -c Release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

COPY --from=build /app ./

ENTRYPOINT ["dotnet", "AutosApi.dll"]