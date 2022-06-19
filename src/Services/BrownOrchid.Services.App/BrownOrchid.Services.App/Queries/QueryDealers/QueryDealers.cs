using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using BrownOrchid.Services.App.Data.Views;
using MediatR;

namespace BrownOrchid.Services.App.Queries.QueryDealers;

public class QueryDealers : IRequest<List<DealerView>>
{

}

public class QueryDealersHandler : IRequestHandler<QueryDealers, List<DealerView>>
{
    private IDealerRepository _repository;

    public QueryDealersHandler(IDealerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<DealerView>> Handle(QueryDealers request, CancellationToken cancellationToken)
    {
        return await _repository.FIndAllAsync();
    }
}