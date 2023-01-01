using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selen001
{
	public class Admin
	{
		private WebDriver Driver;

		//Go to user managment tab
		private readonly By UserManTabXpath = By.XPath("//*[@id='app']/div[1]/div[1]/header/div[2]/nav/ul/li[1]");
		//Go to user tab
		private readonly By UserTabXpath = By.XPath("//*[@id=\'app\']/div[1]/div[1]/header/div[2]/nav/ul/li[1]/ul");
		//Push Add button
		private readonly By AddButtonXpath = By.XPath("//*[@id=\'app\']/div[1]/div[2]/div[2]/div/div[2]/div[1]/button");

        public Admin(WebDriver Driver)
		{
			this.Driver = Driver;
		}

		public AddUser GoToUserAddPage()
		{
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(UserManTabXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(UserTabXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(AddButtonXpath)).Click();

			return new AddUser(Driver);
        }


	}
}

