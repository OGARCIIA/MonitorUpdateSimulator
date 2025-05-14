# 🛠️ Proyecto de Actualización de Monitor - Prueba Técnica

Este proyecto es un simulador de actualizaciones para un proceso llamado "monitor". Básicamente simula cómo se gestionaría la actualización de un servicio en producción, haciendo backup, aplicando cambios y haciendo rollback si algo falla.

## 🧩 Descripción general de lo que realiza el código

1. Busca si hay un proceso llamado `psample` corriendo (como si fuera el monitor) y lo mata.
2. Crea una carpeta de respaldo en una ruta temporal.
3. Aplica los cambios desde la carpeta `C:\Source` hacia `C:\Target`, con base en archivos especiales:
   - `.add`: archivos nuevos que se deben agregar
   - `.upd`: archivos que se deben reemplazar
   - `.del`: archivos que se deben borrar
   - `.xmrg`: archivos que deben transformarse con reglas XDT
   - `.eini`, `.exc`, `.eend`: scripts que se ejecutan al inicio, durante y al final
4. Si algo falla, hace rollback con los archivos de backup.
5. Limpia todo y borra las carpetas temporales.

## 🔧 ¿Qué tuve que hacer para que compilara?

- Agregué una clase `WindowsServiceManager` que no existía en el código original, sólo para simular.
- Inicialicé los loggers `ILog` en todas las clases, usando:
  ```csharp
  private static readonly ILog Log = LogManager.GetLogger(typeof(ClaseActual));
  ```
- Arreglé un `Log.Info(...)` que estaba mal usado con dos parámetros.
- Agregué la inicialización de log4net en el `Main`:
  ```csharp
  log4net.Config.BasicConfigurator.Configure();
  ```
- Hice que el programa cree automáticamente las carpetas `C:\Source` y `C:\Target` si no existen.
- Agregué algunos `Console.WriteLine(...)` para que puedas ver lo que pasa al ejecutar.

## ▶️ Cómo probarlo

1. Crea la carpeta `C:\Source` y pon ahí archivos como:
   - `archivo1.txt.add`
   - `archivo2.txt.upd`
   - `archivo3.txt.del`
2. Crea la carpeta `C:\Target` con algunos archivos para que haya algo que actualizar o eliminar.
3. Ejecuta el programa.
4. Revisa que en `C:\Target` se hayan aplicado los cambios y que `C:\Source` se haya borrado.
