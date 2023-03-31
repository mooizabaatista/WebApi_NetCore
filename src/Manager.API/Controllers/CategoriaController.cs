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
    public class CategoriaController : ControllerBase
    {

        private readonly ICategoriaService _service;
        private readonly IMapper _mapper;

        public CategoriaController(ICategoriaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> Get()
        {
            var categorias = await _service.Get();
            return Ok(categorias);
        }

        [HttpGet]
        [Route("GetById/{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var categoria = await _service.Get(id);
            return Ok(categoria);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] CategoriaDtoFlat categoriaDto)
        {
            try
            {
                categoriaDto = await _service.Create(categoriaDto);
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnSaveEntity,
                    Success = true,
                    Data = categoriaDto
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
        public async Task<IActionResult> Update([FromBody] CategoriaDtoFlat categoriaDto)
        {
            try
            {
                categoriaDto = await _service.Update(categoriaDto);
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnSaveEntity,
                    Success = true,
                    Data = categoriaDto
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

        [HttpDelete]
        [Route("Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {

            var result = await _service.Delete(id);
            if (result)
            {
                return Ok(new ResultViewModel
                {
                    Message = SharedConstants.SuccessOnSaveEntity,
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return BadRequest(new ResultViewModel
                {
                    Message = SharedConstants.FailedOnSaveEntity,
                    Success = false,
                    Data = "Falha ao remover."
                });
            }
        }
    }
}