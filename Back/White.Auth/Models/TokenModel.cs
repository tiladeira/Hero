using System.ComponentModel.DataAnnotations;

namespace White.Auth.Api.Models
{
    public class TokenModel
    {
        [Required(ErrorMessage = "Token is required")]
        public string? Token { get; set; }
    }
}
