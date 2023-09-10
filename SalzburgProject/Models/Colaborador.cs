using SalzburgProject.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace SalzburgProject.Models
{
    public class Colaborador
    {
        [Key]
        public int Id { get; set; }
        [StringLength(120)]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [StringLength(11)]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [ValidCPF(ErrorMessage = "CPF inválido.")]
        public string CPF { get; set; }
        [StringLength(11)]
        [Required(ErrorMessage = "{0} é obrigatório.")]
        [Display(Name = "Telefone")]
        public string? Telephone { get; set; }

        [Required(ErrorMessage = "Por favor, selecione um tipo de colaborador.")]
        [EnumDataType(typeof(ColaboradorTipo), ErrorMessage = "Por favor, selecione um tipo de colaborador.")]
        [Display(Name = "Cargo")]
        public ColaboradorTipo Type { get; set; }
        public ColaboradorStatus Status { get; set; }
        public List<ChavePix>? ChavesPix { get; set; }
        public ICollection<Folga>? Folgas { get; set; }


    }
}
