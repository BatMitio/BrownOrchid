using System.ComponentModel.DataAnnotations;

namespace BrownOrchid.Services.DWH.Data.Entities;

public class PosTerminal
{
    [Key]
    public string TerminalId { get; set; }
    [Required]
    public string DealerId { get; set; }
}