using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTestProject.Pages;
using SeleniumTestProject.Utilities;

namespace SeleniumTestProject.Tests
{
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;

        [SetUp]
        public void SetUp()
        {
            driver = DriverFactory.CreateDriver();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void ValidLoginTest()
        {
            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();

            string message = loginPage.GetFlashMessage();
            Assert.That(message, Does.Contain("You logged into a secure area!"));
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
