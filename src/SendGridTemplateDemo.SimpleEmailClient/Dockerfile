FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SendGridTemplateDemo.SimpleEmailClient/SendGridTemplateDemo.SimpleEmailClient.csproj", "SendGridTemplateDemo.SimpleEmailClient/"]
RUN dotnet restore "SendGridTemplateDemo.SimpleEmailClient/SendGridTemplateDemo.SimpleEmailClient.csproj"
COPY . .
WORKDIR "/src/SendGridTemplateDemo.SimpleEmailClient"
RUN dotnet build "SendGridTemplateDemo.SimpleEmailClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SendGridTemplateDemo.SimpleEmailClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SendGridTemplateDemo.SimpleEmailClient.dll"]
