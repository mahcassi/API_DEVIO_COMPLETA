using AutoMapper;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
using WEBAPI.Controllers;
using WEBAPI.DTOs;

namespace API_DEVIO_COMPLETA.Controllers
{
    [Route("api/produtos")]
    public class ProdutosController : MainController
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutosController(IProdutoRepository produtoRepository, 
                                  IProdutoService produtoService, 
                                  IMapper mapper, 
                                  INotificador notificador) : base(notificador)
        {
            _produtoRepository = produtoRepository;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDTO>> obterTodos()
        {
            return _mapper.Map<IEnumerable<ProdutoDTO>>(await _produtoRepository.ObterProdutosFornecedores());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> ObterPorId(Guid id)
        {
            var produtoDTO = await ObterProduto(id);

            if (produtoDTO == null) return NotFound();

            return CustomResponse(produtoDTO);
        }


        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> Adicionar(ProdutoDTO produtoDTO)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var imagemNome = Guid.NewGuid() + "_" + produtoDTO.Imagem;

            if (!UploadArquivo(produtoDTO.ImagemUpload, imagemNome)) return CustomResponse();

            produtoDTO.Imagem = imagemNome;
            await _produtoService.Adicionar(_mapper.Map<Produto>(produtoDTO));

            return CustomResponse(produtoDTO);
        }

        //[HttpDelete("{id:guid}")]
        //public async Task<ActionResult<ProdutoDTO>> Atualizar(ProdutoDTO produtoDTO, Guid id)
        //{
        //    if (id != produtoDTO.Id) return BadRequest();

        //    if (!ModelState.IsValid) return CustomResponse(ModelState);

        //    await _produtoService.Atualizar(_mapper.Map<Produto>(produtoDTO));

        //    return CustomResponse(produtoDTO);
        //}

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<ProdutoDTO>> Excluir(Guid id)
        {
            var produtoDTO = await ObterProduto(id);

            if (produtoDTO == null) return NotFound();

            await _produtoService.Remover(id);

            return CustomResponse(produtoDTO);
        }

        private bool UploadArquivo(string arquivo, string imgNome)
        {
            var imageDataByteArray = Convert.FromBase64String(arquivo);

            if (string.IsNullOrEmpty(arquivo))
            {
                NotificarErro("Forneça uma imagem para este produto!");
                return false;
            }

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/imagens", imgNome);

            if (System.IO.File.Exists(filePath))
            {
                NotificarErro("Já existe um arquivo com este nome!");
                return false;
            }

            System.IO.File.WriteAllBytes(filePath, imageDataByteArray);

            return true;
        }

        [NonAction]
        private async Task<ProdutoDTO> ObterProduto(Guid id)
        {
            return _mapper.Map<ProdutoDTO>(await _produtoRepository.ObterProdutoFornecedor(id));
        }
    }
}
