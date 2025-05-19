using System;

class Program
{
    static double CalculateTax(double income)
    {
        if (income <= 1000) return 0;
        if (income <= 5000) return (income - 1000) * 0.1;
        if (income <= 10000) return 500 + (income - 5000) * 0.2;
        return 1000 + (income - 10000) * 0.3;
    }

    static void Main()
    {
        Console.Write("Введите доход: ");
        string input = Console.ReadLine() ?? "";
        try
        {
            double income = double.Parse(input);
            if (income < 0) throw new ArgumentException("Отрицательный доход");
            double tax = CalculateTax(income);
            Console.WriteLine($"Налог: {tax} у.е.");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}
