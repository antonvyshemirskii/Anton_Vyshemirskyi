using System;
using System.Xml.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace selen001
{
	public class AddUser
	{
		private WebDriver Driver;

		//Fill in Username
		private readonly By UsernameXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[4]/div/div[2]/input");
		//Fill in password
		private readonly By PasswordXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[1]/div/div[2]/input");
		//confirm password
		private readonly By PasswordConfXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[2]/div/div[2]/div/div[2]/input");
		//fill Employee name
		private readonly By EmployeeNameXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[1]/div/div[2]/div/div[2]/div/div/input");
		//choose Odis Adalwan
		private readonly By OdisXpath = By.XPath("//div[@class='oxd-autocomplete-option' and contains(.,'Odis ')]");
		//fill user role
		private readonly By UserRoleXpath = By.XPath("//div[@class='oxd-select-wrapper' and contains(.,'-- Select --')]");
		//choose user role ESS
		private readonly By ESSXpath = By.XPath("//div[@class='oxd-select-option' and contains(.,'ESS')]");
		//fill status
		private readonly By StatusXpath = By.XPath("//div[@class='oxd-select-wrapper' and contains(.,'-- Select --')]");
		//choose status Enabled
		private readonly By EnabledXpath = By.XPath("//div[@class='oxd-select-option' and contains(.,'Enabled')]");
		//save user
		private readonly By SaveButtonXpath = By.XPath("//*[@id='app']/div[1]/div[2]/div[2]/div/div/form/div[3]/button[2]");

		public AddUser(WebDriver Driver)
		{
			this.Driver = Driver;
		}

		public Users AddNewUser(string username, string password, string employeeName)
		{
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UsernameXpath)).SendKeys(username);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(PasswordXpath)).SendKeys(password);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(PasswordConfXpath)).SendKeys(password);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EmployeeNameXpath)).SendKeys(employeeName);
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(OdisXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UserRoleXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ESSXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(StatusXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(EnabledXpath)).Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(SaveButtonXpath)).Click();

			return new Users(Driver, username);
        }
	}
}

