using CP2.Domain.Entities;

namespace CP2.Domain.Interfaces
{
    public interface IVendedorApplicationService
    {
        VendedorEntity AtualizarVendedor(VendedorEntity vendedor); // Ajuste o tipo de retorno
        VendedorEntity CriarVendedor(VendedorEntity vendedor); // Ajuste o tipo de retorno
        VendedorEntity DeletarDadosVendedor(int id); // Ajuste o tipo de retorno
        VendedorEntity ObterVendedorPorId(int id); // Tipo de retorno correto
        IEnumerable<VendedorEntity> ObterTodosVendedores(); // Ajuste se necessário
    }
}
