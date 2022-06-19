using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using BrownOrchid.Services.App.Data.Views;
using MediatR;

namespace BrownOrchid.Services.App.Queries.QueryDiscounts;

public class QueryDiscounts : IRequest<List<DiscountView>>
{

}

public class QueryDiscountsHandler : IRequestHandler<QueryDiscounts, List<DiscountView>>
{
    private IDiscountRepository _repository;

    public QueryDiscountsHandler(IDiscountRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DiscountView>> Handle(QueryDiscounts request, CancellationToken cancellationToken)
    {
        return await _repository.FIndAllAsync();
    }
}