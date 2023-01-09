using RestSharp;
using RestSharp.Authenticators;
using System.Text.Json.Serialization;

namespace WebAPI
{
    public class Login : AuthenticatorBase
    {
        public string BaseUrl;
        public string ClientId;
        public string ClientSecret;

        public Login(string BaseUrl, string ClientId, string ClientSecret) : base("")
        {
            this.BaseUrl = BaseUrl;
            this.ClientId = ClientId;
            this.ClientSecret = ClientSecret;
        }

        protected override async ValueTask<Parameter> GetAuthenticationParameter(string AccessToken)
        {
            Token = string.IsNullOrEmpty(Token) ? await GetToken() : Token;
            return new HeaderParameter(KnownHeaders.Authorization, Token);
        }

        private async Task<string> GetToken()
        {
            var options = new RestClientOptions(BaseUrl);
            using var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(ClientId, ClientSecret),
            };

            var request = new RestRequest("oauth2/token")
                .AddParameter("grant_type", "client_credentials");
            var response = await client.PostAsync<TokenResponse>(request);
            return $"{response!.TokenType} {response!.AccessToken}";
        }
    }

    public record TokenResponse
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
    }
}