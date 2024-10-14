using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public int Id { get; set; } // Identificador único do fornecedor
        public string Nome { get; set; } // Nome do fornecedor
        public string CNPJ { get; set; } // CNPJ do fornecedor
        public string Endereco { get; set; } // Endereço do fornecedor
        public string Telefone { get; set; } // Telefone de contato do fornecedor
        public string Email { get; set; } // Email do fornecedor
        public DateTime CriadoEm { get; set; } // Data de criação do registro

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);
            if (!validateResult.IsValid)
                throw new ValidationException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.CNPJ)
                .NotEmpty().WithMessage("O CNPJ é obrigatório.")
                .Matches(@"^\d{14}$").WithMessage("O CNPJ deve ter 14 dígitos.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos.");
        }
    }
}
