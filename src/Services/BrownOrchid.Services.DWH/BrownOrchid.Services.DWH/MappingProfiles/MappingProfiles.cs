using AutoMapper;
using BrownOrchid.Services.DWH.Commands.Dealers.CreateDealer;
using BrownOrchid.Services.DWH.Commands.Dealers.LoginDealer;
using BrownOrchid.Services.DWH.Data.Entities;
using BrownOrchid.Services.DWH.DTOs;

namespace BrownOrchid.Services.DWH.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreateDealerCommand, Dealer>();
        CreateMap<RegisterDealerDto, CreateDealerCommand>();
        CreateMap<LoginDealerDto, LoginDealerCommand>();
    }
}