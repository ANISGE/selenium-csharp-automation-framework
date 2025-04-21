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

        [TestCase("wronguser", "wrongpassword")]
        [TestCase("tomsmith", "wrongpassword")]
        [TestCase("wronguser", "SuperSecretPassword!")]
        public void InvalidLoginTest(string username, string password)
        {
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            loginPage.ClickLogin();

            string message = loginPage.GetFlashMessage();
            Console.WriteLine($"Tried: {username}/{password} → {message}");

            Assert.That(message, Does.Contain("Your username is invalid!"));
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
