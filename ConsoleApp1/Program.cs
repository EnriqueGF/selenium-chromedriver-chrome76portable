using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    class Program
    {
        static ChromeDriver driver;

        static ChromeDriver setupDriver()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var options = new ChromeOptions();

            List<string> ls = new List<string>();
            ls.Add("enable-automation");
            options.AddArgument("--disable-extensions");
            options.AddArguments("start-maximized");
            options.AddExcludedArguments(new List<string>() { "enable-automation" });
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddExcludedArguments(ls);
            options.AddArgument("--disable-plugins-discovery");
            // Perfil de Chrome
            options.AddArguments(@"user-data-dir=" + path + @"GoogleChromePortable64\Data\profile");
            options.BinaryLocation = (path + @"GoogleChromePortable64\App\Chrome-bin\chrome.exe");

            var driver = new ChromeDriver(options);

            return driver;
        }


        static void Main(string[] args)
        {

            driver = setupDriver();
            driver.Navigate().GoToUrl("https://google.es");

        }
    }
}
