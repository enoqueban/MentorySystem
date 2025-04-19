# Ruta base del código
$sourcePath = "C:\Users\e.de.andrade.neto\KikeAI\"
$destinationTextFile = "C:\Users\e.de.andrade.neto\KikeAI\MentoringSystem_Actual.txt"

# Eliminar el archivo de texto si ya existe
if (Test-Path $destinationTextFile) {
    Remove-Item $destinationTextFile -Force
    Write-Host "Archivo de texto existente eliminado."
}

# Crear un archivo de texto nuevo
New-Item -ItemType File -Path $destinationTextFile -Force | Out-Null
Write-Host "Archivo de texto creado en: $destinationTextFile"

# Obtener todos los archivos excluyendo los que no queremos, específicamente de la carpeta src
$srcPath = Join-Path -Path $sourcePath -ChildPath "src"
$filesToProcess = Get-ChildItem -Path $srcPath -Recurse -File |
    Where-Object {
        # Excluir archivos en las carpetas bin, obj y node_modules
        $_.FullName -notmatch '\\bin\\' -and
        $_.FullName -notmatch '\\obj\\' -and
        $_.FullName -notmatch '\\node_modules\\' -and
        # Excluir extensiones específicas
        $_.Extension -ne '.pdb' -and
        $_.Extension -ne '.dll' -and
        $_.Extension -ne '.exe' -and
        $_.Extension -ne '.log' -and
        $_.Extension -ne '.db' -and
        # Excluir archivos ps1
        $_.Extension -ne '.ps1'
    }

# Contador para seguimiento
$totalFiles = $filesToProcess.Count
$currentFile = 0

# Procesar cada archivo y agregarlo al archivo de texto
foreach ($file in $filesToProcess) {
    $currentFile++
    # Calcula la ruta relativa desde la carpeta src
    $relativePath = $file.FullName.Substring($srcPath.Length)
    
    # Agregar separador y nombre de archivo al archivo de texto
    $fileSeparator = "`r`n`r`n" + "#" * 80 + "`r`n"
    $fileSeparator += "# ARCHIVO: $relativePath`r`n"
    $fileSeparator += "#" * 80 + "`r`n`r`n"
    
    # Leer el contenido del archivo
    $fileContent = Get-Content -Path $file.FullName -Raw
    
    # Agregar al archivo de texto
    Add-Content -Path $destinationTextFile -Value $fileSeparator
    Add-Content -Path $destinationTextFile -Value $fileContent
    
    # Mostrar progreso
    Write-Progress -Activity "Procesando archivos" -Status "Procesando $currentFile de $totalFiles" -PercentComplete (($currentFile / $totalFiles) * 100)
}

# Mostrar información del archivo de texto creado
if (Test-Path $destinationTextFile) {
    $fileInfo = Get-Item $destinationTextFile
    Write-Host "Archivo de texto creado exitosamente:" -ForegroundColor Green
    Write-Host "  Tamaño: $([math]::Round($fileInfo.Length / 1KB, 2)) KB"
    Write-Host "  Ubicación: $($fileInfo.FullName)"
}
else {
    Write-Host "No se pudo crear el archivo de texto." -ForegroundColor Red
}