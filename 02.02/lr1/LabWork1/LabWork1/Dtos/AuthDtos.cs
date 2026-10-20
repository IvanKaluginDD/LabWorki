public record RegisterDto(string Email, string Password, string FullName, string Role = "student");
public record LoginDto(string Email, string Password);
public record TokenDto(string AccessToken, string TokenType, string Role);
