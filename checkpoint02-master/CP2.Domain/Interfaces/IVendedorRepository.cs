using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorRepository
    {
        VendedorEntity? Atualizar(VendedorEntity vendedorExistente);
        VendedorEntity Criar(VendedorEntity vendedor);
        void DeletarDados(int id);
        VendedorEntity? ObterPorId(int id);
        IEnumerable<VendedorEntity> ObterTodos();
    }
}
