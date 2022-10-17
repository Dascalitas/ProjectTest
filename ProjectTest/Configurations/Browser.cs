using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using ProjectTest.Configurations;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using OpenQA.Selenium.Edge;
using static ProjectTest.ReportsHelper;

namespace ProjectTest.Configurations
{
    public class Browser
    {
        public Browser(ReportsHelper reportsHelper)
        {
            baseURL = ConfigurationManager.AppSettings["url"];
            browser = ConfigurationManager.AppSettings["browser"];
            extentReportsHelper = reportsHelper;
            Init();
        }
        private IWebDriver webDriver;
        private string baseURL;
        private string browser;
        private ExtentReportsHelper extentReportsHelper;

        public void Init()
        {
            switch (browser)
            {
                case "Chrome":
                    webDriver = new ChromeDriver();
                    break;
                case "Firefox":
                    webDriver = new FirefoxDriver();
                    break;
                default:
                    webDriver = new EdgeDriver();
                    break;
            }
            extentReportsHelper.SetStepStatusPass("Browser started.");
            webDriver.Manage().Window.Maximize();
            extentReportsHelper.SetStepStatusPass("Browser maximized.");
            Goto(baseURL);
        }
        public string Title
        {
            get { return webDriver.Title; }
        }
        public IWebDriver getDriver
        {
            get { return webDriver; }
        }
        public void Goto(string url)
        {
            webDriver.Url = url;
            extentReportsHelper.SetStepStatusPass($"Browser navigated to the url [{url}].");
        }
        public void Close()
        {
            webDriver.Quit();
            extentReportsHelper.SetStepStatusPass($"Browser closed.");
        }
    }
}