using System;
using OpenQA.Selenium;
namespace selen001
{
	public class Login
	{
		protected WebDriver Driver;

		private readonly By UsernameXpath = By.XPath("//input[@name='username']");
		private readonly By PasswordXpath = By.XPath("//input[@name='password']");
		private readonly By SubmitButtonXpath = By.XPath("//button[@type='submit']");

		public Login(WebDriver Driver)
		{
			this.Driver = Driver;
		}

		public Home LoginValid(string username, string password)
		{
			// wait for page downloading
			Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
			Driver.FindElement(UsernameXpath).SendKeys(username);
			Driver.FindElement(PasswordXpath).SendKeys(password);
			Driver.FindElement(SubmitButtonXpath).Click();

			return new Home(Driver);
		}
	}
}

