
& Get-ChildItem .\ -include bin,obj -Recurse | ForEach-Object ($_) { Remove-Item $_.FullName -Force -Recurse }

& dotnet build --configuration Release

& dotnet vstest (Get-ChildItem . -recurse -Include "*.Tests.*dll" | ? { $_.FullName -notmatch "\\obj\\?" })
