namespace CreateUseCases.Utils;

public static class CpfUtils
{
    public static bool ValidateCpf(string cpf)
    {
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11 || cpf.All(c => c == cpf[0])) // If all characters are the same
        {
            return false;
        }

        var cpfNumeric = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        int firstCheckDigit = 0;
        for (int i = 0; i < 9; i++)
        {
            firstCheckDigit += cpfNumeric[i] * (10 - i);
        }

        firstCheckDigit = firstCheckDigit % 11;
        if (firstCheckDigit < 2)
        {
            firstCheckDigit = 0;
        }
        else
        {
            firstCheckDigit = 11 - firstCheckDigit;
        }

        int secondCheckDigit = 0;
        for (int i = 0; i < 10; i++)
        {
            secondCheckDigit += cpfNumeric[i] * (11 - i);
        }

        secondCheckDigit = secondCheckDigit % 11;
        if (secondCheckDigit < 2)
        {
            secondCheckDigit = 0;
        }
        else
        {
            secondCheckDigit = 11 - secondCheckDigit;
        }

        return cpfNumeric[9] == firstCheckDigit && cpfNumeric[10] == secondCheckDigit;
    }
}