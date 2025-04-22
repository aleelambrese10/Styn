using Styn.Domain.DTOs;
using Styn.Domain.Entities;
using AutoMapper;
using Styn.Domain.Dtos;


public class MappingProfile : Profile
{
    public MappingProfile()
    {


        CreateMap<UserDTO, ApplicationUser>().ReverseMap();
        CreateMap<AlertasDTO, Alertas>().ReverseMap();
        CreateMap<CelosDTO, Celos>().ReverseMap();
        CreateMap<ColaboradoresDTO, Colaboradores>().ReverseMap();
        CreateMap<ControlLecheroDTO, ControlLechero>().ReverseMap();
        CreateMap<DescartesDTO, Descartes>().ReverseMap();
        CreateMap<DiagnosticoDTO, Diagnostico>().ReverseMap();
        CreateMap<EventosSanitariosDTO, EventosSanitarios>().ReverseMap();
        CreateMap<ExamenGenitalDTO, ExamenGenital>().ReverseMap();
        CreateMap<FichaAnimalDTO, FichaAnimal>().ReverseMap();
        CreateMap<LotesDTO, Lotes>().ReverseMap();
        CreateMap<MetodosDTO, Metodos>().ReverseMap();
        CreateMap<PagoDTO, Pago>().ReverseMap();
        CreateMap<PartosDTO, Partos>().ReverseMap();
        CreateMap<PatologiasUbre, PatologiasUbreDTO>().ReverseMap();
        CreateMap<PatologiasPatasDTO, PatologiasPatas>().ReverseMap();
        CreateMap<RazaDTO, Raza>().ReverseMap();
        CreateMap<RegistroOrdenesDTO, RegistroOrdenes>().ReverseMap();
        CreateMap<SecadoDTO, Secado>().ReverseMap();
        CreateMap<ServiciosDTO, Servicios>().ReverseMap();
        CreateMap<TipoAlertaDTO, TipoAlerta>().ReverseMap();
        CreateMap<TipoDescarteDTO, TipoDescarte>().ReverseMap();
        CreateMap<TipoPartosDTO, TipoPartos>().ReverseMap();
        CreateMap<TipoSecadoDTO, TipoSecado>().ReverseMap();
        CreateMap<TiposServiciosDTO, TiposServicios>().ReverseMap();
        CreateMap<TorosDTO, Toros>().ReverseMap();
        CreateMap<TratamientoDTO, Tratamiento>().ReverseMap();




    }
}

