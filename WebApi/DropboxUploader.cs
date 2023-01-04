using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;

namespace WebApi
{
    public class DropboxUploader : DropboxFactoryClass
    {
        public string url = "";

        // Check file exists on PC
        public override bool CheckFileExist()
        {
            return File.Exists(fileName);
        }

        // Upload file to Dropbox
        public void UploadFile()
        {
            if (CheckFileExist())
            {
                var memory = new MemoryStream(File.ReadAllBytes(fileName));
                var update = DbClient.Files.UploadAsync("/" + fileName, WriteMode.Overwrite.Instance, body: memory);
                update.Wait();
                var link = DbClient.Sharing.CreateSharedLinkWithSettingsAsync("/" + fileName);
                link.Wait();
                url = link.Result.Url;
            }
        }

        // Show success message
        public override void ShowSuccessMessage()
        {
            Console.WriteLine("File uploaded! You can find it here " + url);
        }
    }
}
