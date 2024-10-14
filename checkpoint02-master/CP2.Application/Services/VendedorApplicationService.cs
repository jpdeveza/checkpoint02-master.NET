using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }

        // Método para deletar os dados do vendedor
        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            var vendedor = _repository.ObterPorId(id);
            if (vendedor != null)
            {
                _repository.DeletarDados(id);
                return vendedor;
            }
            return null;
        }

        // Método para obter todos os vendedores
        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        // Método para obter um vendedor pelo ID
        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        // Método para criar um novo vendedor
        public VendedorEntity CriarVendedor(VendedorEntity vendedor)
        {
            return _repository.Criar(vendedor);
        }

        // Método para atualizar os dados de um vendedor existente
        public VendedorEntity? AtualizarVendedor(VendedorEntity vendedor)
        {
            var vendedorExistente = _repository.ObterPorId(vendedor.Id);
            if (vendedorExistente != null)
            {
                vendedorExistente.Nome = vendedor.Nome;
                vendedorExistente.Cpf = vendedor.Cpf;
                vendedorExistente.Endereco = vendedor.Endereco;
                return _repository.Atualizar(vendedorExistente);
            }
            return null;
        }
    }
}
