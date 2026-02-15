@echo off
setlocal enabledelayedexpansion

echo [1/3] Verificando .NET SDK...
dotnet --version >nul 2>&1
if %errorlevel%==0 (
  echo .NET SDK encontrado.
  goto :gitcheck
)

echo .NET SDK nao encontrado. Tentando instalar via winget...
winget --version >nul 2>&1
if %errorlevel%==0 (
  winget install --id Microsoft.DotNet.SDK.8 --silent --accept-package-agreements --accept-source-agreements
) else (
  echo Winget indisponivel. Instale manualmente: https://dotnet.microsoft.com/download
)

:gitcheck
echo [2/3] Verificando Git (opcional)...
git --version >nul 2>&1
if %errorlevel%==0 (
  echo Git encontrado.
) else (
  echo Git nao encontrado. (Opcional)
)

echo [3/3] Dependencias verificadas.
pause
