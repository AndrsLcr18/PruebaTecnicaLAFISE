using AutoMapper;
using PruebaTecnicaLAFISE.Models;
using PruebaTecnicaLAFISE.DTOs;
using System.Security.Principal;

namespace PruebaTecnicaLAFISE.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeo entre Cliente y ClienteDTO
            CreateMap<ClienteDTO, Cliente>();
            CreateMap<Cliente, ClienteDTO>();
           
            // Mapeo entre Cliente y Cliente con validación de ID
            CreateMap<CrearCuentaDTO, Cuenta>()
            .ForMember(dest => dest.Saldo, opt => opt.MapFrom(src => src.SaldoInicial));
            
            // Mapeo entre Cuenta y CuentaDTO
            CreateMap<Cuenta, CuentaDTO>();
            CreateMap<Cuenta, BalanceCuentaDTO>()
                .ForMember(dest => dest.SaldoActual, opt => opt.MapFrom(src => src.Saldo));


        }
    }
}
