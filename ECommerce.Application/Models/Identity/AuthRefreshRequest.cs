namespace ECommerce.Application.Models.Identity
{
    public class AuthRefreshRequest
    {
        public string? Token { get; set; }
        public string? RefreshToken { get; set; }
    }
}
