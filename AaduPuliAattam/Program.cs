using Microsoft.VisualBasic.ApplicationServices;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("UnitTests")]
namespace AaduPuliAattam
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
            ApplicationConfiguration.Initialize();

            GraphParser parser = new();
            Graph g = parser.ParseGraph("C:\\Users\\kyber\\Desktop\\skola\\2023_LS\\C#2.0\\AaduPuliAattam\\AaduPuliAattam\\GameBoards\\Advanced.brd");

            Form1 form = new(g);
            Application.Run(form);

            
        }
    }
}