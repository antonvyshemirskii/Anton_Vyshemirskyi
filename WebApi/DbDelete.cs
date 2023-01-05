using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi
{
    public class DbDelete : DbFactoryClass
    {
        public override bool IsFileExist()
        {
            DbMetaData Meta = new DbMetaData();
            return Meta.IsFileExist();
        }

        public override void ShowSuccessMessage()
        {
            Console.WriteLine("You deleted file properly.");
        }

        public void DeleteFile()
        {
            if (IsFileExist())
            {
                // this loop finds in dropbox file with given name and if found return its metadata
                var Dbfiles = Client.Files.ListFolderAsync(string.Empty);
                foreach (var item in Dbfiles.Result.Entries)
                {
                    if (item.Name == FileName)
                    {
                        Client.Files.DeleteV2Async(item.PathLower);
                    }
                }
            }
        }
    }
}
