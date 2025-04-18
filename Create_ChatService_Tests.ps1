# Crear carpeta del proyecto de test
$testPath = "C:\Users\e.de.andrade.neto\KikeAI\src\ChatService.Tests"
if (-not (Test-Path $testPath)) {
    New-Item -ItemType Directory -Path $testPath | Out-Null
}

# Crear proyecto xUnit
dotnet new xunit -n ChatService.Tests -o $testPath

# Agregar referencias necesarias
dotnet add $testPath\ChatService.Tests.csproj reference ..\ChatService\ChatService.csproj
dotnet add $testPath\ChatService.Tests.csproj reference ..\MentoringSystem.Shared\MentoringSystem.Shared.csproj

# Agregar paquetes de test
dotnet add $testPath\ChatService.Tests.csproj package FluentAssertions
dotnet add $testPath\ChatService.Tests.csproj package coverlet.collector
dotnet add $testPath\ChatService.Tests.csproj package Moq

# Confirmar finalización
Write-Host "Proyecto ChatService.Tests creado y configurado."
