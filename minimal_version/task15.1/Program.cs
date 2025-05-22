using System;
class Program
{
    static int ComputeF(int n)
    {
        if (n < 0) throw new ArgumentException("Неотрицательное число");
        if (n == 0) return 0;
        int coeff_a = 1, coeff_b = 0;
        while (n > 0)
        {
            if (n % 2 == 0)
            {
                coeff_a += coeff_b;
                n /= 2;
            }
            else
            {
                coeff_b += coeff_a;
                n = (n - 1) / 2;
            }
        }
        return coeff_b;
    }
    static void Main()
    {
        Console.Write("Введите n: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            int result = ComputeF(n);
            Console.WriteLine($"Число: {n}\nРезультат: {result}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}