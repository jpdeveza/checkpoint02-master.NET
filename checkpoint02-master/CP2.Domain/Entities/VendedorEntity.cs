using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CP2.Domain.Entities
{
    [Table("tb_vendedor")]
    public class VendedorEntity
    {
        public object Cpf;

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(15)] // Ex: (00) 0000-0000
        public string Telefone { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(200)]
        public string Endereco { get; set; }

        [Required]
        public DateTime DataContratacao { get; set; }

        [Required]
        [Range(0, 100)] // Comissão deve estar entre 0% e 100%
        public decimal ComissaoPercentual { get; set; }

        [Required]
        [Range(0, double.MaxValue)] // Meta mensal deve ser um valor positivo
        public decimal MetaMensal { get; set; }

        [Required]
        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
