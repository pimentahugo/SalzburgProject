using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

public class ValidCPFAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return ValidationResult.Success;
        }

        var cpf = value.ToString();

        if (!IsCpfValid(cpf))
        {
            return new ValidationResult("CPF inválido.");
        }

        return ValidationResult.Success;
    }

    // Função para validar o CPF
    private bool IsCpfValid(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
        {
            return false;
        }

        if (cpf.Distinct().Count() == 1)
        {
            return false;
        }

        int[] numbers = new int[11];
        for (int i = 0; i < 11; i++)
        {
            numbers[i] = int.Parse(cpf[i].ToString());
        }

        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < 9; i++)
        {
            sum1 += numbers[i] * (10 - i);
            sum2 += numbers[i] * (11 - i);
        }

        int remainder1 = sum1 % 11;
        int remainder2 = sum2 % 11;

        if (remainder1 < 2)
        {
            if (numbers[9] != 0)
            {
                return false;
            }
        }
        else if (numbers[9] != 11 - remainder1)
        {
            return false;
        }

        if (remainder2 < 2)
        {
            if (numbers[10] != 0)
            {
                return false;
            }
        }
        else if (numbers[10] != 11 - remainder2)
        {
            return false;
        }

        return true;
    }
}
