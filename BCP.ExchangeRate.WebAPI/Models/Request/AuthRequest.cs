using System.ComponentModel.DataAnnotations;

namespace BCP.ExchangeRate.WebAPI.Models.Request
{
    public class AuthRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}