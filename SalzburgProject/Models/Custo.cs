using SalzburgProject.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SalzburgProject.Models
{
    public class Custo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Descrição do custo")]
        public string Name { get; set; }

        [Display(Name = "Tipo de custo")]
        [Required(ErrorMessage = "Por favor, selecione um tipo de despesa.")]
        [EnumDataType(typeof(TipoCusto), ErrorMessage = "Por favor, selecione um tipo de despesa.")]
        public TipoCusto TipoCusto { get; set; }

        [Display(Name = "Metodo de pagamento")]
        [Required(ErrorMessage = "Por favor, selecione um tipo de pagamento.")]
        [EnumDataType(typeof(TipoPagamento), ErrorMessage = "Por favor, selecione um tipo de pagamento.")]
        public TipoPagamento TipoPagamento { get; set; }

        [Required]
        public bool Parcelado { get; set; }
        public int? QtdParcelamento { get; set; }
        public string? ParcelaAtual { get; set; }

        [Display(Name = "Valor R$")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public DateTime Data { get; set; }
    }
}
