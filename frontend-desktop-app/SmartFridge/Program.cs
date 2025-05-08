using SmartFridge.Services;

namespace SmartFridge
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
            Application.Run(new frmLogin());
        }

        private static void OnApplicationExit(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                try
                {
                    await BackendService.LogoutAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during logout: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }).Wait();
        }
    }
}