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
        public string Name { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um tipo de despesa.")]
        [EnumDataType(typeof(ColaboradorTipo), ErrorMessage = "Por favor, selecione um tipo de despesa.")]
        public TipoCusto TipoCusto { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
