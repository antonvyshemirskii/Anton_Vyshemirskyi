using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace selen001
{
	public class Users
	{
		protected WebDriver Driver;

		//confirm delete
		private readonly By ConfirmDeleteXpath = By.XPath("//button[text()=' Yes, Delete ']");
		// user name
		private readonly string Username;
		//user xpath
		private readonly By UserXpath;
		private readonly By DeleteUserXpath;

        private readonly By AddButtonXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div[2]/div[1]/button");

        public Users(WebDriver Driver, string Username)
		{
			this.Driver = Driver;
			this.Username = Username;
			this.UserXpath = By.XPath("//div[text() = '" + Username + "']");
			this.DeleteUserXpath = By.XPath("//div[@class='oxd-table-row oxd-table-row--with-border' and contains(., '" + Username + "')]//i[@class='oxd-icon bi-trash']");
		}

		public void WaitForLoad()
		{
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AddButtonXpath));

        }

		public bool IsUserExist()
		{
			try
			{
				WaitForLoad();
				Driver.FindElement(UserXpath);

				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
		}

		public void DeleteUser()
		{

			WaitForLoad();

            Driver.FindElement(DeleteUserXpath).Click();
            Driver.FindElement(ConfirmDeleteXpath).Click();
        }
    }
}

