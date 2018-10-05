# BUILD
FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

COPY *.sln .
COPY DotNetHackNight/*.*proj ./DotNetHackNight/
RUN dotnet restore

COPY DotNetHackNight/. ./DotNetHackNight/
WORKDIR /app/DotNetHackNight
RUN dotnet publish -c Release -o out

# RELEASE
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/DotNetHackNight/out ./
ENTRYPOINT ["dotnet", "DotNetHackNight.dll"]

