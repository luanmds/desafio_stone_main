using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using FuncionarioApi.Controllers.DTO;
using FuncionarioApi.Models.Funcionarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private readonly FuncionarioService _funcionarioService;

        public FuncionariosController(FuncionarioService funcionarioService)
        {
            this._funcionarioService = funcionarioService;
        }

        [HttpPost]
        public async Task<IActionResult> AddFuncionario(FuncionarioCreateDTO data)
        {
            try
            {
                await this._funcionarioService.CriarFuncionario(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FuncionarioDTO>> GetFuncionario([Required] long id)
        {
            try
            {
                var funcionario = await this._funcionarioService.ObterFuncionario(id);

                if (funcionario == null) return NotFound(String.Format("Funcionário with ID {0} Not Found.", id));

                return FuncionarioDTO.FuncionarioToDTO(funcionario);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FuncionarioDTO>>> GetAllFuncionario()
        {
            try
            {
                var funcionarios = await this._funcionarioService.ObterTodosFuncionarios();

                List<FuncionarioDTO> funcionariosDTO = new List<FuncionarioDTO>();

                foreach (Funcionario f in funcionarios)
                {
                    funcionariosDTO.Add(FuncionarioDTO.FuncionarioToDTO(f));
                }

                return funcionariosDTO;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}