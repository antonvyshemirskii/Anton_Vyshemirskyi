using RestSharp;

namespace WebAPI
{
    public class Client
    {
        private RestClient client;

        public string BaseUrl = "https://api.dropboxapi.com/";

        public static string GetMetaUrl = "https://api.dropboxapi.com/2/files/get_metadata";

        public static string DeleteUrl = "https://api.dropboxapi.com/2/files/delete_v2";

        public static string UploadUrl = "https://content.dropboxapi.com/2/files/upload";

        public string GenToken = "sl.BWk_UO9rAd5Pzc-x2blMgIVSY6pBmxf89tFF28UZpa-ViHr_vBQBj5-dvLikruElHhR0icP4qMFtZBDwFPNOlLmdPNF20rY02GidAD2PVk9E_hkz-MUfXA8MKzMjqx5TOVWkohbRQys";


        public Client()
        {
            var opt = new RestClientOptions("https://content.dropboxapi.com/2");
            client = new RestClient(opt);
            client.AddDefaultHeader("Authorization", "Bearer" + " " + GenToken);
        }

        public async Task<RestResponse<MetaData>> GetFileMetadata(string FilePath)
        {
            var request = Request.BuildGetRequest(FilePath);
            var response = await client.ExecutePostAsync<MetaData>(request);
            return response;
        }

        public async Task<RestResponse<DeleteFileMetaData>> DeleteFile(string FilePath)
        {
            var request = Request.BuildDeleteRequest(FilePath);
            var response = await client.ExecutePostAsync<DeleteFileMetaData>(request);
            return response;
        }

        public async Task<RestResponse<MetaData>> UploadFile(string LocalFilePath, string FileName)
        {
            var request = Request.BuildPostRequest(LocalFilePath, FileName);
            var response = await client.ExecutePostAsync<MetaData>(request);
            return response;
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
