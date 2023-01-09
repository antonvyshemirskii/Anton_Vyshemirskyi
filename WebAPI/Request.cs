using RestSharp;


namespace WebAPI
{
    public static class Request
    {
        public static RestRequest BuildGetRequest(string FilePath)
        {
            var request = new BuildRequest()
               .SetUrl(Client.GetMetaUrl)
               .SetHeader("Content-Type", "application/json")
               .SetBody<object>(new { include_deleted = false, include_has_explicit_shared_members = false, include_media_info = false, path = FilePath })
               .Build();

            return request;
        }

        public static RestRequest BuildPostRequest(string LocalFilePath, string FileName)
        {
            var request = new BuildRequest()
                .SetUrl(Client.UploadUrl)
                .SetHeader("Dropbox-API-Arg", "{\"path\":\"/" + FileName + "\"}")
                .SetHeader("Content-Type", "application/octet-stream")
                .SetFile(LocalFilePath)
                .Build();

            return request;
        }

        public static RestRequest BuildDeleteRequest(string FilePath)
        {
            var request = new BuildRequest()
                .SetUrl(Client.DeleteUrl)
                .SetHeader("Content-Type", "application/json")
                .SetBody<object>(new { path = FilePath })
                .Build();

            return request;
        }
    }
}