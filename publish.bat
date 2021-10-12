for /f %%a in (VERSION) do (set version=%%a)
echo %version%
nuget pack directui.nuspec
nuget push directui.%version%.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %1
nuget pack microsoft.win32.nuspec
nuget push microsoft.win32.%version%.nupkg -Source https://api.nuget.org/v3/index.json -ApiKey %1
del *.nupkg /S/Q
