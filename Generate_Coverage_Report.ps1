
# Ruta base de la solución
$solutionPath = "C:\Users\e.de.andrade.neto\KikeAI\src"

# Setear archivo de configuración runsettings
$runsettingsPath = "$solutionPath\coverlet.solution.runsettings"

# Si no existe el archivo, crearlo con múltiples módulos incluidos
if (-not (Test-Path $runsettingsPath)) {
@'
<RunSettings>
  <DataCollectionRunSettings>
    <DataCollectors>
      <DataCollector friendlyName="XPlat code coverage">
        <Configuration>
          <Format>cobertura</Format>
          <Include>[NotificationService*]*</Include>
          <Include>[ChatService*]*</Include>
          <Include>[FeedbackService*]*</Include>
          <Include>[PriorityService*]*</Include>
          <Include>[IdentityService*]*</Include>
          <Include>[AuthenticationBFF*]*</Include>
          <Include>[MentoringBFF*]*</Include>
          <Include>[ChatBFF*]*</Include>
          <Include>[AnalysisBFF*]*</Include>
          <Include>[NotificationsBFF*]*</Include>
          <Include>[AdminBFF*]*</Include>
          <IncludePrivate>true</IncludePrivate>
        </Configuration>
      </DataCollector>
    </DataCollectors>
  </DataCollectionRunSettings>
</RunSettings>
'@ | Set-Content $runsettingsPath -Encoding UTF8
}

# Ejecutar tests con cobertura
Write-Host "Ejecutando pruebas con cobertura..."
dotnet test $solutionPath\src.sln --collect:"XPlat Code Coverage" --settings $runsettingsPath

# Instalar reportgenerator si no está instalado
if (-not (Get-Command "reportgenerator.exe" -ErrorAction SilentlyContinue)) {
    dotnet tool install -g dotnet-reportgenerator-globaltool
    $env:Path += ";$env:USERPROFILE\.dotnet\tools"
}

# Buscar el último archivo .cobertura.xml generado
$coverageFile = Get-ChildItem -Path $solutionPath -Recurse -Filter coverage.cobertura.xml | Sort-Object LastWriteTime -Descending | Select-Object -First 1

if ($coverageFile) {
    $reportOutput = "$solutionPath\coverage-report"
    reportgenerator -reports:$coverageFile.FullName -targetdir:$reportOutput -reporttypes:Html
    Start-Process "$reportOutput\index.html"
    Write-Host "Reporte generado en $reportOutput"
} else {
    Write-Host "No se encontró archivo de cobertura para generar el reporte."
}
