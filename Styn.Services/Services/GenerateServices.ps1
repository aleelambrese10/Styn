# Plantilla para el Service
$serviceTemplate = @"
using AutoMapper;
using Styn.Application.Services;
using Styn.Application.Services.Common;
using Styn.Domain.Dtos;
using Styn.Domain.Entities;
using Styn.Infrastructure.Repositories.Common;

// El namespace se ajusta para no incluir 'Module'
namespace Application.Services
{
    // La interfaz y la clase usan directamente {ClassName}
    public interface I{ClassName}Service : IGenericService<{ClassName}DTO>
    {
    }

    public class {ClassName}Service : GenericService<{ClassName}, {ClassName}DTO>, I{ClassName}Service
    {
        public {ClassName}Service(IGenericRepository<{ClassName}> repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
"@

# Función para generar el archivo de Service en el directorio actual
function Generate-ServiceFileHere {
    param (
        [string]$className,
        [string]$currentPath # La ruta donde se ejecuta el script
    )

    # Reemplazar el marcador de posición con el nombre de la clase en la plantilla
    # Ajusta el namespace eliminando la parte del módulo
    $serviceContent = $serviceTemplate -replace '{ClassName}', $className `
                                     -replace 'namespace Application\.Modules\.\{ClassName\}Module\.Services', 'namespace Application.Services'

    # Definir el nombre de archivo del Service en el directorio actual
    $serviceFileName = Join-Path -Path $currentPath -ChildPath "$($className)Service.cs"

    # Escribir el contenido al archivo de Service
    try {
        $serviceContent | Out-File -FilePath $serviceFileName -Encoding utf8 -ErrorAction Stop
        Write-Host "Archivo Service '$($className)Service.cs' generado en: $currentPath"
    }
    catch {
        Write-Error "Error al escribir el archivo Service: $($_.Exception.Message)"
    }
}

# --- Ejecución del Script ---

# Obtener la ruta del directorio donde se está ejecutando el script
# $PSScriptRoot es la variable automática para esto en un script guardado.
# Si se ejecuta línea por línea en la consola, usar (Get-Location).Path
if ($PSScriptRoot) {
    $executionPath = $PSScriptRoot
} else {
    $executionPath = (Get-Location).Path
    Write-Warning "Ejecutando fuera de un archivo .ps1. El archivo se generará en el directorio actual de la consola: $executionPath"
}


# Pedir al usuario que ingrese el nombre de la clase
$className = Read-Host "Ingrese el nombre de la clase para el Service"
if ([string]::IsNullOrWhiteSpace($className)) {
    Write-Error "El nombre de la clase no puede estar vacío."
    exit
}

# Generar el archivo de Service en el directorio actual
Generate-ServiceFileHere -className $className -currentPath $executionPath

Write-Host "Proceso de generación de Service completado."

