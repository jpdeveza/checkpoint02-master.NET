using CP2.Application.Dtos;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CP2.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedorApplicationService _vendedorService;

        public VendedorController(IVendedorApplicationService vendedorService)
        {
            _vendedorService = vendedorService;
        }

        /// <summary>
        /// Obtém todos os vendedores cadastrados.
        /// </summary>
        /// <returns>Uma lista de todos os vendedores.</returns>
        [HttpGet]
        public IActionResult ObterTodosVendedores()
        {
            var vendedores = _vendedorService.ObterTodosVendedores();
            return Ok(vendedores);
        }

        /// <summary>
        /// Obtém um vendedor pelo ID.
        /// </summary>
        /// <param name="id">O ID do vendedor a ser obtido.</param>
        /// <returns>Os dados do vendedor correspondente ou NotFound se não for encontrado.</returns>
        [HttpGet("{id}")]
        public IActionResult ObterVendedorPorId(int id)
        {
            var vendedor = _vendedorService.ObterVendedorPorId(id);
            if (vendedor == null)
            {
                return NotFound();
            }
            return Ok(vendedor);
        }

        /// <summary>
        /// Cria um novo vendedor.
        /// </summary>
        /// <param name="vendedor">Os dados do novo vendedor a ser criado.</param>
        /// <returns>O vendedor recém-criado com o status Created.</returns>
        [HttpPost]
        public IActionResult CriarVendedor([FromBody] VendedorEntity vendedor)
        {
            var novoVendedor = _vendedorService.CriarVendedor(vendedor);
            return CreatedAtAction(nameof(ObterVendedorPorId), new { id = novoVendedor.Id }, novoVendedor);
        }

        /// <summary>
        /// Atualiza um vendedor existente.
        /// </summary>
        /// <param name="id">O ID do vendedor a ser atualizado.</param>
        /// <param name="vendedor">Os novos dados do vendedor.</param>
        /// <returns>NoContent se a atualização for bem-sucedida ou NotFound se o vendedor não for encontrado.</returns>
        [HttpPut("{id}")]
        public IActionResult AtualizarVendedor(int id, [FromBody] VendedorEntity vendedor)
        {
            if (id != vendedor.Id)
            {
                return BadRequest();
            }

            var vendedorAtualizado = _vendedorService.AtualizarVendedor(vendedor);
            if (vendedorAtualizado == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Deleta um vendedor existente.
        /// </summary>
        /// <param name="id">O ID do vendedor a ser deletado.</param>
        /// <returns>NoContent se a exclusão for bem-sucedida ou NotFound se o vendedor não for encontrado.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeletarVendedor(int id)
        {
            var vendedorDeletado = _vendedorService.DeletarDadosVendedor(id);
            if (vendedorDeletado == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
