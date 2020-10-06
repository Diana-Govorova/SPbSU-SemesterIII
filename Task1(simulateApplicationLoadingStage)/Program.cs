using System;
using System.Threading.Tasks;

namespace Task1_simulateApplicationLoadingStage_
{
    class Program
    {
        private static string result = "Program loaded successfully!";

        private static void Main()
        {
            try
            {
                var splash = Task.Run(() => ShowSplash());
                splash.Wait();
                var license = splash.ContinueWith(ant => RequestLicense(), TaskContinuationOptions.NotOnFaulted);
                var errorOfRequestLicense = license.ContinueWith(ant => Console.WriteLine(ant.Exception), TaskContinuationOptions.OnlyOnFaulted);
                var checkForUpdate = splash.ContinueWith(ant => CheckForUpdate(), TaskContinuationOptions.NotOnFaulted);
                var errorOfCheckForUpdate = checkForUpdate.ContinueWith(ant => Console.WriteLine(ant.Exception), TaskContinuationOptions.OnlyOnFaulted);
                var downloadUpdate = checkForUpdate.ContinueWith(ant => DownloadUpdate(), TaskContinuationOptions.NotOnFaulted);
                var errorOfDownloadUpdate = downloadUpdate.ContinueWith(ant => Console.WriteLine(ant.Exception), TaskContinuationOptions.OnlyOnFaulted);
                var setupMenus = license.ContinueWith(ant => SetupMenus(), TaskContinuationOptions.NotOnFaulted);
                var errorOfSetupMenus = setupMenus.ContinueWith(ant => Console.WriteLine(ant.Exception), TaskContinuationOptions.OnlyOnFaulted);
                var display = Task.Factory.ContinueWhenAll(new[] { downloadUpdate, setupMenus }, tasks => DisplayWelcome())
                    .ContinueWith(ant => HideSplash());
                display.Wait();
                Console.WriteLine($"{result}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Show Splash
        /// </summary>
        private static void ShowSplash()
        {
            string text = "Show splash";
            Console.WriteLine(text);
        }

        /// <summary>
        /// Request License
        /// </summary>
        private static void RequestLicense()
        {
            string text = "Request license";
            Console.WriteLine(text);
            RandomException(text);
        }

        /// <summary>
        /// Check for update.
        /// </summary>
        private static void CheckForUpdate()
        {
            string text = "Check for update";
            Console.WriteLine(text);
            RandomException(text);
        }

        /// <summary>
        /// Download update.
        /// </summary>
        private static void DownloadUpdate()
        {
            string text = "Download update";
            Console.WriteLine(text);
            RandomException(text);
        }

        /// <summary>
        /// Setup menus.
        /// </summary>
        private static void SetupMenus()
        {
            string text = "Setup menus";
            Console.WriteLine(text);
            RandomException(text);
        }

        /// <summary>
        /// Display welcome.
        /// </summary>
        private static void DisplayWelcome()
        {
            string text = "Display welcome";
            Console.WriteLine(text);
        }

        /// <summary>
        /// Hide splash.
        /// </summary>
        private static void HideSplash()
        {
            string text = "Hide splash";
            Console.WriteLine(text);
        }

        /// <summary>
        /// Create the random exception.
        /// </summary>
        /// <param name="name">The name of the method in which the error occurred</param>
        private static void RandomException(string name)
        {
            try
            {
                Random random = new Random();
                int value = random.Next(0, 15);
                if ((value % 5) == 0)
                {
                    throw new MyException(name);
                }
            }
            catch (MyException exception)
            {
                Console.WriteLine($" Program launch error : {exception.Message} ");
                result = "Failed to load the program";
            }
        }
    }
}