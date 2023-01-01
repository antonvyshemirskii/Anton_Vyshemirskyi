using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Safari;
namespace selen001
{
	public class UnitTest2
	{
		readonly WebDriver Driver = new SafariDriver();

		[SetUp]

		public void Init()
		{
			Driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
			Driver.Manage().Window.Maximize();
		}
		[Test]
		public void Test()
		{
			Login SignIn = new Login(Driver);
			Home HomePage = SignIn.LoginValid("Admin", "admin123");
			Admin AdminPage = HomePage.GotoAdmin();
			AddUser AddUserPage = AdminPage.GoToUserAddPage();
			Users NewUser = AddUserPage.AddNewUser("Anton Vyshemirskyi", "Anton123#", "Odis ");

			Assert.IsTrue(NewUser.IsUserExist()); // check that new user was added succesfully
			NewUser.DeleteUser();

			Assert.IsFalse(NewUser.IsUserExist()); // check that new user was deleted succesfully
		}
		[TearDown]
		public void Finish()
		{
			Driver.Close();
		}
	}
}

