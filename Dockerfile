FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src


COPY . ./
RUN dotnet restore


RUN dotnet publish BookLibraryAPI/BookLibraryAPI.csproj -c Release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app .

ENV ASPNETCORE_ENVIRONMENT=Docker
COPY .aspnet/https/dockercert.pfx /https/

ENV ASPNETCORE_Kestrel__Certificates__Default__Password="CertDocker"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path="/https/dockercert.pfx"


EXPOSE 8080

ENTRYPOINT ["dotnet", "BookLibraryAPI.dll"]