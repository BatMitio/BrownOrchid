using AutoMapper;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Queries.QueryDiscounts;

public class QueryWaitingDiscounts : IRequest<List<DiscountView>>
{
    
}

public class QueryWaitingDiscountsHandler : IRequestHandler<QueryWaitingDiscounts, List<DiscountView>>
{
    private AppDbContext _context;
    private IMapper _mapper;

    public QueryWaitingDiscountsHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DiscountView>> Handle(QueryWaitingDiscounts request, CancellationToken cancellationToken)
    {
        return await _context.Discounts
            .Include(d => d.Dealer)
            .Where(d => d.DiscountStatus == Discount.DiscountStatusEnum.WAITING)
            .Select(d => _mapper.Map<DiscountView>(d))
            .ToListAsync();
    }
}