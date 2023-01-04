using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi
{
    public class DropboxFileDeleter : DropboxFactoryClass
    {
        public override bool CheckFileExist()
        {
            DropboxFileMetadata DbFMeta = new DropboxFileMetadata();
            return DbFMeta.CheckFileExist();
        }

        public override void ShowSuccessMessage()
        {
            Console.WriteLine("You deleted file properly.");
        }

        public void DeleteFile()
        {
            if (CheckFileExist())
            {
                // Loop through all files in dropbox and if found one with given name return its metadata
                var filesDb = DbClient.Files.ListFolderAsync(string.Empty);
                foreach (var item in filesDb.Result.Entries)
                {
                    if (item.Name == fileName)
                    {
                        DbClient.Files.DeleteV2Async(item.PathLower);
                    }
                }
            }
        }
    }
}
