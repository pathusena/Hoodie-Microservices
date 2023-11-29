namespace Hoodie.Services.AuthAPI.Dto
{
    public class ResponseDto
    {
        public object? Ressult { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
