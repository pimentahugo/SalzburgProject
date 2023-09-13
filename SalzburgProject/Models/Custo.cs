using SalzburgProject.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SalzburgProject.Models
{
    public class Custo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public TipoCusto TipoCusto { get; set; }

        [Required]
        public DateTime Data { get; set; }
    }
}
