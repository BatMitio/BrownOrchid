namespace BrownOrchid.Gateways.Portal.Data.Models.Employee;

public class CheckPasswordModel
{
    public string Username { get; set; }
    public string Password { get; set; }

    public CheckPasswordModel(string username, string password)
    {
        Username = username;
        Password = password;
    }
}