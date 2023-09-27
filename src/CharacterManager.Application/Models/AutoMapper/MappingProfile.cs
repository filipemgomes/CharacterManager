using AutoMapper;
using CharacterManager.Domain.Entities;
using CharacterManager.Domain.Enums;

namespace CharacterManager.Application.Models.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Personagem, PersonagemModel>()
                .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => Enum.Parse<TipoProfissao>(src.Profissao)));

            CreateMap<Personagem, ListaPersonagemModel>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.PontosDeVida <= 0 ? "Morto" : "Vivo"))
                .ForMember(dest => dest.Profissao, opt => opt.MapFrom(src => src.Profissao.ToString()));

            CreateMap<LogBatalha, LogBatalhaModel>();






        }

    }
}
