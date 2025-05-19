# 🛠️ Proyecto de Actualización de Monitor - Evidencia Final

Este sistema simula el proceso de actualización automática de archivos de un componente tipo "monitor". Incluye respaldo, aplicación de cambios y rollback en caso de error.

---

## ✅ ¿Qué hace el código?

1. **Detiene el proceso activo del monitor** si existe (`psample.exe`).
2. **Crea un respaldo** de la carpeta destino.
3. **Aplica archivos** desde la carpeta `Source/` hacia `Target/`, con comandos como:
   - `.add`: agregar archivo
   - `.upd`: actualizar archivo
   - `.del`: eliminar archivo
4. **Rollback** si algo falla (se restauran archivos desde el backup).
5. **Limpieza final** y eliminación de temporales.

---

## 📂 Archivos de prueba utilizados

En el paquete `archivos_prueba_actualizacion.zip` se incluyen:

### Source/
- `nuevo.txt.add`: nuevo archivo a agregar.
- `reemplazo.txt.upd`: archivo a actualizar.
- `borrar.txt.del`: archivo a eliminar.

### Target/
- `reemplazo.txt`: archivo previo que será reemplazado.
- `borrar.txt`: archivo que será eliminado.

---

## ▶️ ¿Cómo se ejecuta?

1. Extrae el contenido del ZIP en `C:/Source` y `C:/Target`.
2. Corre el programa con el siguiente `Main()`:

```csharp
static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            string source = @"C:\Source";
            string target = @"C:\Target";

            if (!Directory.Exists(source))
                Directory.CreateDirectory(source);

            if (!Directory.Exists(target))
                Directory.CreateDirectory(target);
            Console.WriteLine("Iniciando actualización...");
            Sample.MonitorUpdaterManagerSample.UpdateMonitor(@"C:\Source", @"C:\Target", "1.0.0");
            Console.WriteLine("Actualización finalizada.");
            Console.ReadKey();
        }
```

3. Verifica en consola y en la carpeta `Target` que:
   - Se agregó `nuevo.txt`
   - Se actualizó `reemplazo.txt`
   - Se eliminó `borrar.txt`

---

## ⚙️ Métodos previamente incompletos ya implementados

```csharp
private void CopyFile(string sourceFile, string targetFile)
{
    var dir = Path.GetDirectoryName(targetFile);
    if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
    File.Copy(sourceFile, targetFile, true);
}

private void RemoveFile(string targetFile)
{
    if (File.Exists(targetFile))
        File.Delete(targetFile);
}

private void ExecuteBats(...) 
{
    Console.WriteLine($"Simulando ejecución de script: {file}");
}
```

---

## 📊 Diagramas entregados

- Diagrama de flujo (`diagrama_flujo.png`)
- Diagrama de secuencia (`diagrama_secuencia.png`)
- Diagrama de clases (`diagrama_clases.png`)

Todos fueron corregidos y coinciden con la lógica real del sistema.

---

## 🧪 Evidencia de ejecución (simulada)

A continuación, se muestra el resultado de aplicar los cambios con los archivos de prueba:

📄 [Ver evidencia_resultado.txt](evidencia_resultado.txt)

Este archivo incluye:

- Estado inicial de la carpeta `Target` (antes de ejecutar)
- Cambios aplicados por el programa
- Estado final de la carpeta `Target`

También agregue un archivo "diagramas y evidencias.zip" donde se pueden ver evidencias en imagenes de lo descrito anteriormente así como los diagramas corregidos.