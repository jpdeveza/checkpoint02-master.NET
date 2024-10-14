using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedorApplicationService _fornecedorService;

        public FornecedorController(IFornecedorApplicationService fornecedorService)
        {
            _fornecedorService = fornecedorService;
        }

        /// <summary>
        /// Obtém um fornecedor específico pelo ID.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser obtido.</param>
        /// <returns>Retorna os dados do fornecedor correspondente ou NotFound se não for encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult ObterFornecedorPorId(int id)
        {
            var fornecedor = _fornecedorService.ObterFornecedorPorId(id);
            if (fornecedor == null)
            {
                return NotFound();
            }
            return Ok(fornecedor);
        }

        /// <summary>
        /// Cria um novo fornecedor.
        /// </summary>
        /// <param name="fornecedor">Objeto FornecedorEntity contendo os dados do fornecedor a ser criado.</param>
        /// <returns>Retorna o fornecedor recém-criado com o status Created.</returns>
        [HttpPost]
        public IActionResult CriarFornecedor([FromBody] FornecedorEntity fornecedor)
        {
            var novoFornecedor = _fornecedorService.CriarFornecedor(fornecedor);
            return CreatedAtAction(nameof(ObterFornecedorPorId), new { id = novoFornecedor.Id }, novoFornecedor);
        }

        /// <summary>
        /// Atualiza os dados de um fornecedor existente.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser atualizado.</param>
        /// <param name="fornecedor">Os novos dados do fornecedor.</param>
        /// <returns>Retorna NoContent se a atualização for bem-sucedida ou NotFound se o fornecedor não for encontrado.</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarFornecedor(int id, [FromBody] FornecedorEntity fornecedor)
        {
            if (id != fornecedor.Id)
            {
                return BadRequest();
            }

            var fornecedorAtualizado = _fornecedorService.AtualizarFornecedor(fornecedor);
            if (fornecedorAtualizado == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um fornecedor existente pelo ID.
        /// </summary>
        /// <param name="id">O ID do fornecedor a ser deletado.</param>
        /// <returns>Retorna NoContent se a exclusão for bem-sucedida ou NotFound se o fornecedor não for encontrado.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarFornecedor(int id)
        {
            var fornecedorDeletado = _fornecedorService.DeletarDadosFornecedor(id);
            if (fornecedorDeletado == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
