namespace TibiaMarkerMerge
{

    internal static class Program
    {

        public static string tibiaMapMarkerFile;

        public static string tibiaMapsFile;
        public static long tibiaMapsFileSize = 0;

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Main());
        }

    }

}
