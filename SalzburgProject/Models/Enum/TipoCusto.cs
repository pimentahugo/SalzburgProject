using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace SalzburgProject.Models.Enum
{
    public enum TipoCusto
    {
        [Display(Name = "Custos operacionais")]
        CustoOperacional = 1,
        [Display(Name = "Investimentos")]
        Investimento = 2,
        [Display(Name = "Logística")]
        Logistica = 3,
        [Display(Name = "Funcionários")]
        Funcionario = 4,
        [Display(Name = "Impostos e taxas")]
        Imposto = 5
    }
}
