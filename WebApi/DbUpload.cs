using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;

namespace WebApi
{
    public class DbUpload : DbFactoryClass
    {
        public string URL = "";

        
        public override bool IsFileExist()
        {
            return File.Exists(FileName);
        }

        // Upload file to Dropbox
        public void UploadFile()
        {
            if (IsFileExist())
            {

                var memory = new MemoryStream(File.ReadAllBytes(FileName));
                var uploaded = Client.Files.UploadAsync("/" + FileName, WriteMode.Overwrite.Instance, body: memory);
                uploaded.Wait();
                var link = Client.Sharing.CreateSharedLinkWithSettingsAsync("/" + FileName);
                link.Wait();
                URL = link.Result.Url;
            }
        }

       
        public override void ShowSuccessMessage()
        {
            Console.WriteLine("File uploaded! just here: " + URL);
        }
    }
}
