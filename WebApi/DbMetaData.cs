using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Dropbox.Api;
using Dropbox.Api.FileRequests;
using Dropbox.Api.Files;

namespace WebApi
{
    public class DbMetaData : DbFactoryClass
    {
        public override bool IsFileExist()
        {

            DbUpload Upload = new DbUpload();
            Upload.UploadFile();
            bool result = Upload.URL.Length > 0 ? true : false;
            return result;
        }

        public override void ShowSuccessMessage()
        {
            Metadata file = GetFileMetaData();
            if (file != null)
            {
                Console.WriteLine("Data received");
                Console.WriteLine("Name: " + file.Name);
                Console.WriteLine("Path: " + file.PathDisplay);

            } 
        }

        public Metadata GetFileMetaData()
        {
            if (IsFileExist())
            {
                var Dbfiles = Client.Files.ListFolderAsync(string.Empty);
                foreach (var item in Dbfiles.Result.Entries)
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
