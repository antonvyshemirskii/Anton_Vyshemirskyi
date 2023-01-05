using System;
using System.Collections.Generic;
using System.Text;

using Dropbox.Api;

namespace WebApi
{
    public abstract class DbFactoryClass
    {
        // general fields
        static private string token = "sl.BWRJw1ci9u0WvAbqI93ToD9L9JSWXDiaL5GJgIQwnIg56SUWIie1OvKpBxAwG3kJ8AWfyKK0htp6YppNY2YpesOarHffh41970q1V0dFJBCcEfLtsK3XMUaXEa7Gn_1BHE31JfWd-8wg";
        public DropboxClient Client = new DropboxClient(token);
        public string FileName = "file_test.txt";


        public abstract bool IsFileExist();
        
        public abstract void ShowSuccessMessage();
        
        

        static void Main(string[] args)
        {
            
        }
    }
}
