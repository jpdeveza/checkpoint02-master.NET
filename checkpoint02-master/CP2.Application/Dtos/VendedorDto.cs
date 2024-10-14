using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public int Id { get; set; } // Identificador único do vendedor
        public string Nome { get; set; } // Nome do vendedor
        public string Email { get; set; } // Email do vendedor
        public string Telefone { get; set; } // Telefone de contato do vendedor
        public DateTime DataNascimento { get; set; } // Data de nascimento do vendedor
        public string Endereco { get; set; } // Endereço do vendedor
        public DateTime DataContratacao { get; set; } // Data de contratação do vendedor
        public decimal ComissaoPercentual { get; set; } // Percentual de comissão do vendedor
        public decimal MetaMensal { get; set; } // Meta mensal do vendedor
        public DateTime CriadoEm { get; set; } // Data de criação do registro

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);
            if (!validateResult.IsValid)
                throw new ValidationException(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email é inválido.");

            RuleFor(x => x.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d{10,11}$").WithMessage("O telefone deve ter 10 ou 11 dígitos.");

            RuleFor(x => x.ComissaoPercentual)
                .InclusiveBetween(0, 100).WithMessage("O percentual de comissão deve estar entre 0 e 100.");

            RuleFor(x => x.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser maior que 0.");

            RuleFor(x => x.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.")
                .Must(BeAValidAge).WithMessage("A idade mínima permitida é 18 anos.");

            RuleFor(x => x.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("A data de contratação não pode ser futura.");
        }

        private bool BeAValidAge(DateTime date)
        {
            var age = DateTime.Now.Year - date.Year;
            if (date > DateTime.Now.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}
