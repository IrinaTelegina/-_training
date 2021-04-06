using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAdressbookTests
{
    public class TestBase
    {
        protected ApplicationManager app;
        protected IWebDriver driver;

        [SetUp]
        public void SetupApplicationManager()
        {
            app = ApplicationManager.GetInstanse();
        }

    }
}
