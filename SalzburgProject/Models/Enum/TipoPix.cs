using System.ComponentModel.DataAnnotations;

namespace SalzburgProject.Models.Enum
{
    public enum TipoPix : int
    {
        [Display(Name = "CPF ou CNPJ")]
        CPFCnpj = 1,
        Telefone = 2,
        Email = 3,
        [Display(Name = "Chave aleatória")]
        Aleatoria = 4
    }
}
