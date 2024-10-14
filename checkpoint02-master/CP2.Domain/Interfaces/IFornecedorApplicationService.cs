using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IFornecedorApplicationService
    {
        FornecedorEntity AtualizarFornecedor(FornecedorEntity fornecedor); // Ajuste o tipo de retorno
        FornecedorEntity CriarFornecedor(FornecedorEntity fornecedor); // Ajuste o tipo de retorno
        FornecedorEntity DeletarDadosFornecedor(int id); // Ajuste o tipo de retorno
        FornecedorEntity ObterFornecedorPorId(int id); // Já está correto
    }
}
