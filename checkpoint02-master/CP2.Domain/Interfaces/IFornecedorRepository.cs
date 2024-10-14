using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorRepository
    {
        FornecedorEntity? Atualizar(FornecedorEntity fornecedorExistente);
        FornecedorEntity Criar(FornecedorEntity fornecedor);
        void DeletarDados(int id);
        FornecedorEntity ObterPorId(int id); // Método de obtenção pelo ID
        IEnumerable<FornecedorEntity> ObterTodos();
    }
}
