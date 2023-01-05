using System;
namespace webapi
{
	public class DbDelete:DbFactoryClass
	{
        public override bool IsFileExist()
        {
            DbMetaData Meta = new DbMetaData();
            return Meta.IsFileExist();
        }
        public override void ShowSuccess()
        {
            Console.WriteLine("You deleted file properly.");
        }

        public void DeleteFile()
        {
            if (IsFileExist())
            {
                // this loop finds in dropbox file with given name and if found return its metadata
                var filesDb = Client.Files.ListFolderAsync(string.Empty);
                foreach (var item in filesDb.Result.Entries)
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

