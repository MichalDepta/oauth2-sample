using System;
using Newtonsoft.Json;

namespace Sample.Client
{
    [System.Diagnostics.DebuggerDisplay("TokenType={TokenType}; ExpiresIn={ExpiresIn}; Token={AccessToken}")]
    public class AuthorizationResponse
    {
        public AuthorizationResponse(string accessToken, int expiresIn, string tokenType)
        {
            AccessToken = accessToken;
            ExpiresIn = expiresIn;
            TokenType = tokenType;
        }

        [JsonProperty("access_token")] 
        public string AccessToken { get; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; }

        [JsonProperty("token_type")]
        public string TokenType { get; }
    }
}