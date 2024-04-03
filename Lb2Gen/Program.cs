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
            manager.InitPipolation(20);
            for (int i = 0; i < 100; i++)
            {
                manager.GetNewGeneration();
            }
        }
    }
}