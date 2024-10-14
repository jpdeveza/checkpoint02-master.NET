using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Método para criar um novo fornecedor
        public FornecedorEntity Criar(FornecedorEntity fornecedor)
        {
            _context.Fornecedores.Add(fornecedor);
            _context.SaveChanges();
            return fornecedor;
        }

        // Método para deletar um fornecedor
        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedores.Find(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                _context.SaveChanges();
            }
            return fornecedor;
        }

        // Método para obter um fornecedor por ID
        public FornecedorEntity? ObterPorId(int id)
        {
            return _context.Fornecedores.Find(id);
        }

        // Método para obter todos os fornecedores
        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            return _context.Fornecedores.AsNoTracking().ToList();
        }

        // Método para atualizar um fornecedor existente
        public FornecedorEntity? Atualizar(FornecedorEntity fornecedor)
        {
            var fornecedorExistente = _context.Fornecedores.Find(fornecedor.Id);
            if (fornecedorExistente != null)
            {
                _context.Entry(fornecedorExistente).CurrentValues.SetValues(fornecedor);
                _context.SaveChanges();
                return fornecedorExistente;
            }
            return null;
        }

        void IFornecedorRepository.DeletarDados(int id)
        {
            throw new NotImplementedException();
        }
    }
}
    