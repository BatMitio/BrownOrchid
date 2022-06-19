using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Queries.QueryPosTerminals;

public class QueryPosTerminals : IRequest<List<PosTerminal>>
{
    
}

public class QueryPosTerminalsHandler : IRequestHandler<QueryPosTerminals, List<PosTerminal>>
{
    private AppDbContext _context;

    public QueryPosTerminalsHandler(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<PosTerminal>> Handle(QueryPosTerminals request, CancellationToken cancellationToken)
    {
        return await _context.PosTerminals.ToListAsync();
    }
}