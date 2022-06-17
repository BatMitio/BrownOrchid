using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BrownOrchid.Services.DWH.Data.Entities;

public class Dealer : IdentityUser
{
    [Required]
    public DateTime RegistrationDate { get; set; }
}