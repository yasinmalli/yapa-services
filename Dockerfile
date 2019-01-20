# build
FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /build

# restore
COPY yapa-api/yapa-api.csproj ./yapa-api/
RUN dotnet restore yapa-api/yapa-api.csproj
COPY yapa-unittests/yapa-unittests.csproj ./yapa-unittests/
RUN dotnet restore yapa-unittests/yapa-unittests.csproj

# todo: RUN ls -AlR ---------------
# copy
COPY . .

# test
RUN dotnet test yapa-unittests/yapa-unittests.csproj

# publish
RUN dotnet publish yapa-api/yapa-api.csproj -o /publish

# Runtime stage
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
COPY --from=build /publish /app
WORKDIR /app
ENTRYPOINT ["dotnet", "yapa-api.dll"]