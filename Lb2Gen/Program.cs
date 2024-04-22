using System.Diagnostics;

namespace Lb2Gen
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //Application.Run(new Form1());
            EvolutionManager manager = new EvolutionManager();
            Stopwatch sw = Stopwatch.StartNew();
            manager.InitPipolation(5000);
            double err = 1000;
            while (err > 0.0005)
            {
                err = manager.GetNewGeneration();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}