using BrownOrchid.Common.Domain.Types;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Repositories.Interfaces;
using MediatR;

namespace BrownOrchid.Services.App.Commands.ApproveDiscountCommand;

public class ApproveDiscountCommand : IRequest<ApiResponse>
{
    public string DiscountId { get; set; }
    public string EmployeeId { get; set; }
}

public class ApproveDiscountCommandHandler : IRequestHandler<ApproveDiscountCommand, ApiResponse>
{
    private IApprovalRepository _repository;
    private IDiscountRepository _discountRepository;

    public ApproveDiscountCommandHandler(IApprovalRepository repository, IDiscountRepository discountRepository)
    {
        _repository = repository;
        _discountRepository = discountRepository;
    }

    public async Task<ApiResponse> Handle(ApproveDiscountCommand request, CancellationToken cancellationToken)
    {
        var result = await _repository.ApproveAsync(request.EmployeeId, request.DiscountId);
        if (result is null)
            return new ApiResponse("Fail", new[] { "Could not save approval!" });
        var approvals = await _repository.FindAllByDiscountIdAsync(request.DiscountId);
        if (approvals.Count >= 2)
        {
            var discount = await _discountRepository.FindByIdAsync(request.DiscountId);
            discount.DiscountStatus = Discount.DiscountStatusEnum.ACTIVE;
            await _discountRepository.UpdateAsync(discount);
        }
        return new ApiResponse("Successfully approved!");
    }
}