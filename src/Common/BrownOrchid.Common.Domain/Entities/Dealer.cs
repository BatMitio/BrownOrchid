using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BrownOrchid.Common.Domain.Entities;

public class Dealer : IdentityUser
{
    [Required]
    public DateTime RegistrationDate { get; set; }
}