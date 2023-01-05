using System;

using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;

namespace webapi
{
	public class DbMetaData:DbFactoryClass
	{

        public override bool IsFileExist()
        {
            DbUpload Upload = new DbUpload();
            Upload.UploadFile();
            bool result = Upload.URL.Length > 0 ? true : false;
            return result;
        }
        public override void ShowSuccess()
        {
            Metadata file = GetMetadata();
            if (file != null)
            {
                Console.WriteLine("Name: " + file.Name);
                Console.WriteLine("Path: " + file.PathDisplay);
                Console.WriteLine("ID: " + file.AsFile.Id);
                Console.WriteLine("Modified: " + file.AsFile.ClientModified);
            }
        }

        public Metadata GetMetadata()
        {
            if (IsFileExist())
            {
                //this loop finds one with given name return its metadata
                var filesDb = Client.Files.ListFolderAsync(string.Empty);
                foreach (var item in filesDb.Result.Entries)
                {
                    if (item.Name == FileName)
                    {
                        return item;
                    }
                }
            }

            return null;
        }

    }
}

