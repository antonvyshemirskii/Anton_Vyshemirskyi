using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selen001
{
	public class Home
	{
		private WebDriver Driver;
        
        private readonly By AdminXpath = By.XPath("//*[@id=\'app\']/div[1]/div[1]/aside/nav/div[2]/ul/li[1]/a/span");


        public Home(WebDriver Driver)
		{
			this.Driver = Driver;
		}

        public Admin GotoAdmin()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(AdminXpath)).Click();
            return new Admin(Driver);
        }
    }

}

