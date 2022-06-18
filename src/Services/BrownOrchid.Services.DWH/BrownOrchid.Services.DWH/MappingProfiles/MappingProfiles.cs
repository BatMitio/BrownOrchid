using AutoMapper;
using BrownOrchid.Services.DWH.Commands.BankEmployees.CreateBankEmployee;
using BrownOrchid.Services.DWH.Commands.BankEmployees.LoginBankEmployee;
using BrownOrchid.Services.DWH.Commands.Dealers.CreateDealer;
using BrownOrchid.Services.DWH.Commands.Dealers.LoginDealer;
using BrownOrchid.Common.Domain.Entities;
using BrownOrchid.Services.DWH.DTOs;

namespace BrownOrchid.Services.DWH.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        //Dealer
        CreateMap<CreateDealerCommand, Dealer>();
        CreateMap<RegisterDealerDto, CreateDealerCommand>();
        CreateMap<LoginDealerDto, LoginDealerCommand>();
        
        //BankEmployee
        CreateMap<CreateBankEmployeeCommand, BankEmployee>();
        CreateMap<RegisterBankEmployeeDto, CreateBankEmployeeCommand>();
        CreateMap<LoginBankEmployeeDto, LoginBankEmployeeCommand>();
    }
}