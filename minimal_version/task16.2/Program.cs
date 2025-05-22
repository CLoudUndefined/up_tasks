using System;
class Program
{
    static double ComputeProduct(int n)
    {
        if (n <= 0) throw new ArgumentException("Натуральное число");
        double product = 1.0;
        for (int i = 1; i <= n; i++)
        {
            double factorial = 1.0;
            for (int j = 1; j <= i; j++) factorial *= j;
            product *= 2.0 + 1.0 / factorial;
        }
        return product;
    }
    static void Main()
    {
        Console.Write("Введите n: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            double result = ComputeProduct(n);
            Console.WriteLine($"Число: {n}\nРезультат: {result:F10}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}