using AutoMapper;
using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.App.Data.Entities;
using BrownOrchid.Services.App.Data.Views;

namespace BrownOrchid.Services.App.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Dealer, DealerView>();
        CreateMap<Discount, DiscountView>()
            .ForMember(dv => dv.DealerId, 
                opt => opt.MapFrom(src => src.Dealer.Id))
            .ForMember(dv => dv.DealerName,
                opt => opt.MapFrom(src => src.Dealer.UserName));
    }
}