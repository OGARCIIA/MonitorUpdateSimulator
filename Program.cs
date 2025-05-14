using System;

namespace MonitorUpdateSimulator
{
    class Program
    {
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
    }
}
