using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Queries.QueryPosTerminals;

public class QueryPosTerminals : IRequest<List<PosTerminalView>>
{
}

public class QueryPosTerminalsHandler : IRequestHandler<QueryPosTerminals, List<PosTerminalView>>
{
    private AppDbContext _context;

    public QueryPosTerminalsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PosTerminalView>> Handle(QueryPosTerminals request, CancellationToken cancellationToken)
    {
        List<PosTerminal> terminals = await _context.PosTerminals.ToListAsync();
        return terminals
            .Select(t => new PosTerminalView() { DealerId = t.DealerId, TerminalId = t.TerminalId })
            .ToList();
    }
}