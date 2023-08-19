namespace Application.Dtos.Request
{
    public class UserSignUpRequestDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }
}
