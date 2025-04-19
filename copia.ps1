# Ruta base del código
$sourcePath = "C:\Users\e.de.andrade.neto\KikeAI\"
$destinationZip = "C:\Users\e.de.andrade.neto\KikeAI\MentoringSystem_Actual.zip"

# Eliminar el archivo zip si ya existe
if (Test-Path $destinationZip) {
    Remove-Item $destinationZip -Force
    Write-Host "Archivo zip existente eliminado."
}

# Crear un directorio temporal
$tempDir = Join-Path -Path $env:TEMP -ChildPath ([System.Guid]::NewGuid().ToString())
New-Item -ItemType Directory -Path $tempDir | Out-Null
Write-Host "Directorio temporal creado en: $tempDir"

# Crear un subdirectorio específico en el directorio temporal para preservar la estructura
$tempSrcDir = Join-Path -Path $tempDir -ChildPath "src"
New-Item -ItemType Directory -Path $tempSrcDir | Out-Null

# Obtener todos los archivos excluyendo los que no queremos, específicamente de la carpeta src
$srcPath = Join-Path -Path $sourcePath -ChildPath "src"
$filesToCompress = Get-ChildItem -Path $srcPath -Recurse -File |
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

# Copiar los archivos manteniendo la estructura de directorios correcta
foreach ($file in $filesToCompress) {
    # Calcula la ruta relativa desde la carpeta src
    $relativePath = $file.FullName.Substring($srcPath.Length)
    
    # Construye la ruta completa en el directorio temporal
    $destPath = Join-Path -Path $tempSrcDir -ChildPath $relativePath
    $destDir = Split-Path -Path $destPath -Parent
    
    # Crea el directorio de destino si no existe
    if (-not (Test-Path $destDir)) {
        New-Item -ItemType Directory -Path $destDir -Force | Out-Null
    }
    
    # Copia el archivo
    Copy-Item -Path $file.FullName -Destination $destPath -Force
}

# Comprimir el directorio temporal, incluyendo la carpeta 'src'
try {
    Compress-Archive -Path "$tempDir\*" -DestinationPath $destinationZip -CompressionLevel Optimal
    Write-Host "Solución comprimida en: $destinationZip"
}
catch {
    Write-Host "Error al comprimir archivos: $_" -ForegroundColor Red
}
finally {
    # Limpiar el directorio temporal
    if (Test-Path $tempDir) {
        Remove-Item -Path $tempDir -Recurse -Force
        Write-Host "Directorio temporal eliminado."
    }
}

# Mostrar información del archivo zip creado
if (Test-Path $destinationZip) {
    $zipInfo = Get-Item $destinationZip
    Write-Host "Archivo ZIP creado exitosamente:" -ForegroundColor Green
    Write-Host "  Tamaño: $([math]::Round($zipInfo.Length / 1MB, 2)) MB"
    Write-Host "  Ubicación: $($zipInfo.FullName)"
}
else {
    Write-Host "No se pudo crear el archivo ZIP." -ForegroundColor Red
}