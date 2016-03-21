using System.Threading.Tasks;
using Refit;

namespace Sample.Client
{
    public interface IAuthorizationService
    {
        [Post("")]
        [Headers(
            "Authorization: Basic cmVzb3VyY2Vvd25lcmNsaWVudDpjbGllbnRzZWNyZXQ=",
            "Content-Type: x-www-form-urlencoded")]
        Task<AuthorizationResponse> Authorize([Body(BodySerializationMethod.UrlEncoded)] UserCredentials userCredentials);
    }
}

