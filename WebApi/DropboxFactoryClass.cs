using System;
using System.Collections.Generic;
using System.Text;

using Dropbox.Api;

namespace WebApi
{
    public abstract class DropboxFactoryClass
    {
        // Fields universal for every class
        static private string token = "sl.BWRJw1ci9u0WvAbqI93ToD9L9JSWXDiaL5GJgIQwnIg56SUWIie1OvKpBxAwG3kJ8AWfyKK0htp6YppNY2YpesOarHffh41970q1V0dFJBCcEfLtsK3XMUaXEa7Gn_1BHE31JfWd-8wg";
        public DropboxClient DbClient = new DropboxClient(token);
        public string fileName = @"FileName.txt";

        // Mehtod which checks whether file exists
        public abstract bool CheckFileExist();
        // Method which shows message of operation success
        public abstract void ShowSuccessMessage();
        
        
        static void Main(string[] args)
        {
            
        }
    }
}
