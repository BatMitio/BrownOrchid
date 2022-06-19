using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.App.Commands.CreateDiscountCommand;

public class CreateDiscountCommand : IRequest<ApiResponse<string?>>
{
    public string DealerId { get; set; }
    public int Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

public class CreateDiscountCommandHandler : IRequestHandler<CreateDiscountCommand, ApiResponse<string?>>
{
    private IDealerRepository _dealerRepository;
    private IDiscountRepository _discountRepository;

    public CreateDiscountCommandHandler(IDealerRepository dealerRepository, IDiscountRepository discountRepository)
    {
        _dealerRepository = dealerRepository;
        _discountRepository = discountRepository;
    }

    public async Task<ApiResponse<string?>> Handle(CreateDiscountCommand request, CancellationToken cancellationToken)
    {
        var dealer = await _dealerRepository.FindByIdAsync(request.DealerId);
        var discount = new Discount()
        {
            Amount = request.Amount, Dealer = dealer, StartDate = request.StartDate, EndDate = request.EndDate,
            DiscountStatus = Discount.DiscountStatusEnum.WAITING
        };
        discount = await _discountRepository.SaveAsync(discount);
        if (discount is null)
            return new ApiResponse<string?>(null, "Fail",new [] {"Unable to save the discount in the database"});
        return new ApiResponse<string?>(discount.DiscountId);
    }
}