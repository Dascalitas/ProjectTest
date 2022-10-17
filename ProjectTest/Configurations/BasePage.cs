using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ProjectTest.ReportsHelper;

namespace ProjectTest.Configurations
{
    public class BasePage
    {
        public BasePage(Browser browser, ExtentReportsHelper extentReportsHelper)
        {
            _browser = browser;
            _extentReportsHelper = extentReportsHelper;
        }
        Browser _browser { get; }
        ExtentReportsHelper _extentReportsHelper { get; set; }
        private T GetPages<T>() where T : new()
        {
            var page = (T)Activator.CreateInstance(typeof(T), _browser.getDriver, _extentReportsHelper);
            PageFactory.InitElements(_browser.getDriver, page);
            return page;
        }
        public Home Home => GetPages<Home>();
        public Computers Computers => GetPages<Computers>();
    }
}
