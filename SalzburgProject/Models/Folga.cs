using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalzburgProject.Models
{
    public class Folga
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data da folga")]
        public DateTime DataFolga { get; set; }
        [ForeignKey("Colaborador")]
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
