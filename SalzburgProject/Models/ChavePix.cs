using SalzburgProject.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalzburgProject.Models
{
    public class ChavePix
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }
        [Required]
        public TipoPix? Type { get; set; }
        [MaxLength(32)]
        [Required]
        public string? KeyPix { get; set; }
        public int? ColaboradorId { get; set; }
        public Colaborador? Colaborador { get; set; }
    }
}
