using API_DEVIO_COMPLETA.DTOs;
using AutoMapper;
using DevIO.Business.Models;
using WEBAPI.DTOs;

namespace WEBAPI.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<Fornecedor, FornecedorDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<ProdutoDTO, Produto>();
            CreateMap<ProdutoImagemDTO, Produto>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>()
                .ForMember(dest => dest.NomeFornecedor, opt => opt.MapFrom(src => src.Fornecedor.Nome));
        }   
    }
}
