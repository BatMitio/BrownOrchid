using System.ComponentModel.DataAnnotations;

namespace BrownOrchid.Services.DWH.Data.Entities;

public class PosTerminal
{
    [Key]
    public string TerminalId { get; set; }
    public Dealer? Dealer { get; set; }

    public PosTerminal()
    {
        TerminalId = Guid.NewGuid().ToString();
    }
}