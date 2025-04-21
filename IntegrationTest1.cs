using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestProject
{
    public class BasicTest
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            Assert.That(driver.Title, Does.Contain("The Internet"));
        }

        [TearDown]
        public void TearDown()
        {
            if (driver != null)
            {
                driver.Quit();      // closes browser
                driver.Dispose();   // releases system resources
            }
        }
    }
}
