@echo off
setlocal

echo Restaurando pacotes...
dotnet restore
if errorlevel 1 goto :fail

echo Publicando executavel unico para Windows x64...
dotnet publish -c Release -r win-x64 --self-contained true /p:PublishSingleFile=true -o publish
if errorlevel 1 goto :fail

echo.
echo Build concluido!
echo Executavel: publish\PcOptimizer300.exe
pause
exit /b 0

:fail
echo.
echo Falha no build. Rode deps.bat e tente novamente.
pause
exit /b 1
