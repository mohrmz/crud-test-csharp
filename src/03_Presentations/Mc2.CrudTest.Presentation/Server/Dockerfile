#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/03_Presentations/Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj", "src/03_Presentations/Mc2.CrudTest.Presentation/Server/"]
COPY ["src/00_Framework/Framework.Endpoints/Framework.Endpoints.csproj", "src/00_Framework/Framework.Endpoints/"]
COPY ["src/00_Framework/Framework.Core/Framework.Core.csproj", "src/00_Framework/Framework.Core/"]
COPY ["src/01_Core/Mc2.CrudTest.Core.ApplicationServices/Mc2.CrudTest.Core.ApplicationServices.csproj", "src/01_Core/Mc2.CrudTest.Core.ApplicationServices/"]
COPY ["src/01_Core/Mc2.CrudTest.Core.Contracts/Mc2.CrudTest.Core.Contracts.csproj", "src/01_Core/Mc2.CrudTest.Core.Contracts/"]
COPY ["src/01_Core/Mc2.CrudTest.Core.Domain/Mc2.CrudTest.Core.Domain.csproj", "src/01_Core/Mc2.CrudTest.Core.Domain/"]
COPY ["src/01_Core/Mc2.CrudTest.Core.RequestResponse/Mc2.CrudTest.Core.RequestResponse.csproj", "src/01_Core/Mc2.CrudTest.Core.RequestResponse/"]
COPY ["src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands/Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands.csproj", "src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructure.Data.SqlServer.Commands/"]
COPY ["src/00_Framework/Framework.Infrastructures/Framework.Infrastructures.csproj", "src/00_Framework/Framework.Infrastructures/"]
COPY ["src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries/Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries.csproj", "src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructure.Data.SqlServer.Queries/"]
COPY ["src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructures.Data.EventsSourcings/Mc2.CrudTest.Infrastructures.Data.EventsSourcings.csproj", "src/02_Infrastructures/Data/Mc2.CrudTest.Infrastructures.Data.EventsSourcings/"]
COPY ["src/03_Presentations/Mc2.CrudTest.Presentation/Client/Mc2.CrudTest.Presentation.Client.csproj", "src/03_Presentations/Mc2.CrudTest.Presentation/Client/"]
COPY ["src/03_Presentations/Mc2.CrudTest.Presentation/Shared/Mc2.CrudTest.Presentation.Shared.csproj", "src/03_Presentations/Mc2.CrudTest.Presentation/Shared/"]
RUN dotnet restore "src/03_Presentations/Mc2.CrudTest.Presentation/Server/Mc2.CrudTest.Presentation.Server.csproj"
COPY . .
WORKDIR "/src/src/03_Presentations/Mc2.CrudTest.Presentation/Server"
RUN dotnet build "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Mc2.CrudTest.Presentation.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Mc2.CrudTest.Presentation.Server.dll"]