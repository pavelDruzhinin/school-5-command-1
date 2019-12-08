FROM microsoft/dotnet:2.2-aspnetcore-runtime
EXPOSE 80/tcp

COPY /src/bin/Release/netcoreapp2.2/linux-x64/publish .

ENTRYPOINT ["dotnet", "chatbot.dll"]
