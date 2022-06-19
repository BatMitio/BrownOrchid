using System.ComponentModel.DataAnnotations;

namespace BrownOrchid.Common.Domain.Entities;

public class PosTerminal
{
    [Key]
    public string TerminalId { get; set; }
    public string DealerId { get; set; }

    public PosTerminal()
    {
        TerminalId = Guid.NewGuid().ToString();
    }
}