using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        // Método para criar um novo vendedor
        public VendedorEntity Criar(VendedorEntity vendedor)
        {
            _context.Vendedores.Add(vendedor);
            _context.SaveChanges();
            return vendedor;
        }

        // Método para deletar um vendedor
        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedores.Find(id);
            if (vendedor != null)
            {
                _context.Vendedores.Remove(vendedor);
                _context.SaveChanges();
            }
            return vendedor;
        }

        // Método para obter um vendedor por ID
        public VendedorEntity? ObterPorId(int id)
        {
            return _context.Vendedores.Find(id);
        }

        // Método para obter todos os vendedores
        public IEnumerable<VendedorEntity> ObterTodos()
        {
            return _context.Vendedores.AsNoTracking().ToList();
        }

        // Método para atualizar um vendedor existente
        public VendedorEntity? Atualizar(VendedorEntity vendedor)
        {
            var vendedorExistente = _context.Vendedores.Find(vendedor.Id);
            if (vendedorExistente != null)
            {
                _context.Entry(vendedorExistente).CurrentValues.SetValues(vendedor);
                _context.SaveChanges();
                return vendedorExistente;
            }
            return null;
        }

        void IVendedorRepository.DeletarDados(int id)
        {
            throw new NotImplementedException();
        }
    }
}
