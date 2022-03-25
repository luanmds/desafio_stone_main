using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Exceptions;
using FuncionarioApi.Controllers.DTO;
using FuncionarioApi.Models.ContraCheque;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FuncionarioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContraChequeController : ControllerBase
    {
        private readonly ContraChequeService _contraChequeService;

        public ContraChequeController(ContraChequeService contraChequeService)
        {
            this._contraChequeService = contraChequeService;
        }

        [HttpGet("/funcionario/{funcId}/gerar")]
        public async Task<ActionResult<ContraChequeDTO>> GenerateContraCheque([Required] long funcId)
        {
            try
            {
                ContraCheque contraCheque = await this._contraChequeService.CalcularDeFuncionario(funcId);
                return ContraChequeDTO.ToDTO(contraCheque);
            }
            catch (FuncionarioNotFound e)
            {
                return NotFound(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }


    }
}