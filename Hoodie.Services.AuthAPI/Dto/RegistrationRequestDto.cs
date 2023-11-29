namespace Hoodie.Services.AuthAPI.Dto
{
    public class RegistrationRequestDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
