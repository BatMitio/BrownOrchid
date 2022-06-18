
using Microsoft.AspNetCore.Identity;

namespace BrownOrchid.Services.Clients.Data.Entities;

public class Client : IdentityUser
{
    public string CardNumber { get; set; }
    public DateTime RegistrationDate { get; set; }
}