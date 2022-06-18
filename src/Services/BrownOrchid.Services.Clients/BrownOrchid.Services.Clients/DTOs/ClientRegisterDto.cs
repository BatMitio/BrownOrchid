namespace BrownOrchid.Services.Clients.DTOs;

public class ClientRegisterDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CardNumber { get; set; }

    public ClientRegisterDto()
    {
        
    }
    
    public ClientRegisterDto(string? username, string? password, string? email, string? phoneNumber, string? cardNumber)
    {
        Username = username;
        Password = password;
        Email = email;
        PhoneNumber = phoneNumber;
        CardNumber = cardNumber;
    }
}