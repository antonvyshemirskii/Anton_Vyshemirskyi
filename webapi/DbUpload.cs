using System;

using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;

namespace webapi
{
	public class DbUpload : DbFactoryClass
	{
		public string URL = "";

        public override bool IsFileExist()
        {
            return File.Exists(FileName);
        }

        public override void ShowSuccess()
        {
            Console.WriteLine("Operation is successed. You can find uploaded file here " + URL);
        }

        // method that upload file to dropbox
        public void UploadFile()
        {
            if (IsFileExist())
            {
                MemoryStream memory = new MemoryStream(File.ReadAllBytes(FileName));
                var update = Client.Files.UploadAsync("/" + FileName, WriteMode.Overwrite.Instance, body: memory);
                update.Wait();
                var link = Client.Sharing.CreateSharedLinkWithSettingsAsync("/" + FileName);
                link.Wait();
                URL = link.Result.Url;
            }
        }

    }
}

