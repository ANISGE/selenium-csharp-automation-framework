using OpenQA.Selenium;

namespace SeleniumTestProject.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver driver;

        // Constructor
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Locators
        private IWebElement UsernameInput => driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => driver.FindElement(By.CssSelector("button.radius"));
        private IWebElement FlashMessage => driver.FindElement(By.Id("flash"));

        // Actions
        public void EnterUsername(string username)
        {
            UsernameInput.Clear();
            UsernameInput.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Clear();
            PasswordInput.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public string GetFlashMessage()
        {
            return FlashMessage.Text;
        }
    }
}
