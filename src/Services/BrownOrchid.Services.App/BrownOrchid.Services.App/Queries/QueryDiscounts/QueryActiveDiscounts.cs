using AutoMapper;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Persistence;
using BrownOrchid.Services.App.Data.Views;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BrownOrchid.Services.App.Queries.QueryDiscounts;

public class QueryActiveDiscounts : IRequest<List<DiscountView>>
{
    
}

public class QueryActiveDiscountsHandler : IRequestHandler<QueryActiveDiscounts, List<DiscountView>>
{
    private AppDbContext _context;
    private IMapper _mapper;

    public QueryActiveDiscountsHandler(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<DiscountView>> Handle(QueryActiveDiscounts request, CancellationToken cancellationToken)
    {
        return await _context.Discounts.Where(d => d.DiscountStatus == Discount.DiscountStatusEnum.ACTIVE)
            .Select(d => _mapper.Map<DiscountView>(d))
            .ToListAsync();
    }
}