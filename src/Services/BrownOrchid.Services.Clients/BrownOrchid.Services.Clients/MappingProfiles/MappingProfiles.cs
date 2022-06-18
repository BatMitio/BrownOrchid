using AutoMapper;
using BrownOrchid.Services.Clients.Commands.RegisterClientCommand;
using BrownOrchid.Services.Clients.Data.Entities;
using BrownOrchid.Services.Clients.DTOs;

namespace BrownOrchid.Services.Clients.MappingProfiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ClientRegisterDto, RegisterClientCommand>();
        CreateMap<RegisterClientCommand, Client>();
    }
}