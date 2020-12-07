FROM registry.cn-hangzhou.aliyuncs.com/yoyosoft/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM registry.cn-hangzhou.aliyuncs.com/yoyosoft/dotnet/core/sdk AS build
WORKDIR /src

COPY ["NuGet.Config", "src/NuGet.Config"]
COPY ["src/Facebook.Marketing.Api/Facebook.Marketing.Api.csproj", "src/Facebook.Marketing.Api/"]
COPY ["src/FaceBook.Marketing.SDK/FaceBook.Marketing.SDK.csproj", "src/FaceBook.Marketing.SDK/"]
RUN dotnet restore  --configfile "src/NuGet.Config" "src/Facebook.Marketing.Api/Facebook.Marketing.Api.csproj"

COPY . .
WORKDIR "/src/src/Facebook.Marketing.Api"
RUN dotnet build "Facebook.Marketing.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Facebook.Marketing.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "Facebook.Marketing.Api.dll"]