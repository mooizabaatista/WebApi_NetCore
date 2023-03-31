using System;
using System.Threading.Tasks;
using AutoMapper;
using Manager.API.ViewModels;
using Manager.Core.Shared;
using Manager.Services.Dtos;
using Manager.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Manager.API.ControllersCateogoria
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _service;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var produtos = await _service.Get();
            return Ok(produtos);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var produto = await _service.Get(id);
            return Ok(produto);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] ProdutoDtoFlat produtoDto)
        {
            try
            {
                produtoDto = await _service.Create(produtoDto);
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnSaveEntity,
                    Success = true,
                    Data = produtoDto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = SharedConstants.FailedOnSaveEntity,
                    Success = false,
                    Data = ex.Message
                });
            }
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] ProdutoDtoFlat produtoDto)
        {
            try
            {
                produtoDto = await _service.Update(produtoDto);
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnUpdateEntity,
                    Success = true,
                    Data = produtoDto
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResultViewModel
                {
                    Message = SharedConstants.FailedOnUpdateEntity,
                    Success = false,
                    Data = ex.Message
                });
            }
        }

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _service.Delete(id);
            if (result)
            {
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnRemoveEntity,
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return BadRequest(new ResultViewModel
                {
                    Message = SharedConstants.FailedOnRemoveEntity,
                    Success = false,
                    Data = "Falha ao remover."
                });
            }
        }
    }
}