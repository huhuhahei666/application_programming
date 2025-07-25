using OfficeOpenXml;
using SQL;

namespace WinForms_singleselection
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        /// 
        private static SQLHelper _sqlHelper;
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            _sqlHelper = new SQLHelper("Data Source=.;Initial Catalog=tblStudnts;Integrated Security=True");
            ApplicationConfiguration.Initialize();
            Application.Run(new FormLogin(_sqlHelper));
        }
    }
}