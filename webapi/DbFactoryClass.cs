using System;
using Dropbox.Api;

namespace webapi
{
	public abstract class DbFactoryClass
	{
		//general fields 
		static private string token = "sl.BWRJw1ci9u0WvAbqI93ToD9L9JSWXDiaL5GJgIQwnIg56SUWIie1OvKpBxAwG3kJ8AWfyKK0htp6YppNY2YpesOarHffh41970q1V0dFJBCcEfLtsK3XMUaXEa7Gn_1BHE31JfWd-8wg";
		public DropboxClient Client = new DropboxClient(token);
		public string FileName = "file_test.txt";

		//method  checks file exist or not
		public abstract bool IsFileExist();

		//method shows message that operation is performed properly
		public abstract void ShowSuccess();

		static void Main(string[] args)
		{

		}
    }
}

