using System.ComponentModel.DataAnnotations;

namespace SalzburgProject.Models
{
    public class ChavePix
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string KeyPix { get; set; }
        public int ColaboradorId { get; set; }
        public Colaborador Colaborador { get; set; }
    }
}
