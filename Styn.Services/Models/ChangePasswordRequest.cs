namespace Styn.Application.Models
{
    public class ChangePasswordRequest
    {
        public string NewPassword { get; set; }
        public string OldPassword { get; set; }

        public string Email { get; set; }
    }
}
