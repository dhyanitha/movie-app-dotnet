FROM microsoft/aspnetcore-build:latest AS build-env
WORKDIR /app
# Copy csproj and restore as distinct layers
COPY server.csproj ./
RUN dotnet restore 
# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out
#Build runtime images
FROM microsoft/aspnetcore:latest 
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "server.dll"]