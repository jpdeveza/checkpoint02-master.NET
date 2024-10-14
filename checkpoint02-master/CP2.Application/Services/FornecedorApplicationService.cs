using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using System.Collections.Generic;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        // Método para deletar os dados do fornecedor
        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            var fornecedor = _repository.ObterPorId(id);
            if (fornecedor != null)
            {
                _repository.DeletarDados(id);
                return fornecedor;
            }
            return null;
        }

        // Método para obter o fornecedor pelo ID
        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        // Método para criar um novo fornecedor
        public FornecedorEntity CriarFornecedor(FornecedorEntity fornecedor)
        {
            return _repository.Criar(fornecedor);
        }

        // Método para atualizar os dados de um fornecedor existente
        public FornecedorEntity? AtualizarFornecedor(FornecedorEntity fornecedor)
        {
            var fornecedorExistente = _repository.ObterPorId(fornecedor.Id);
            if (fornecedorExistente != null)
            {
                fornecedorExistente.Nome = fornecedor.Nome;
                fornecedorExistente.Cnpj = fornecedor.Cnpj;
                fornecedorExistente.Endereco = fornecedor.Endereco;
                fornecedorExistente.Telefone = fornecedor.Telefone;
                fornecedorExistente.Email = fornecedor.Email;
                return _repository.Atualizar(fornecedorExistente);
            }
            return null;
        }

        // Método para obter todos os fornecedores
        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }
    }
}
