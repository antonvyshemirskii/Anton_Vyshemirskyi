
using RestSharp;
namespace WebAPI
{
	public class BuildRequest
	{
        private RestRequest request;

        public BuildRequest SetUrl(string Url)
        {
            request = new RestRequest(Url, Method.Post);
            return this;
        }

        public BuildRequest SetHeader(string key, string value)
        {
            request.AddHeader(key, value);
            return this;
        }


        public BuildRequest SetBody<T>(T body) where T : class
        {
            request.AddJsonBody(body);
            return this;
        }

        public BuildRequest SetFile(string FilePath)
        {
            byte[] FileData = File.ReadAllBytes(FilePath);
            request.AddParameter("application/octet-stream", FileData, ParameterType.RequestBody);
            return this;
        }

        public RestRequest Build()
        {
            return request;
        }
    }
}

