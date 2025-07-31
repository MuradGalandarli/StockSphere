namespace StockSphere.Application.Feature.Query.Login
{
    public class LoginQueryResponse
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}