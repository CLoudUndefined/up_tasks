using System;
class Program
{
    static (int total, int even) CountDivisors(int n)
    {
        if (n <= 0) throw new ArgumentException("Натуральное число");
        int total = 0, even = 0;
        for (int i = 1; i <= n; i++)
            if (n % i == 0)
            {
                total++;
                if (i % 2 == 0) even++;
            }
        return (total, even);
    }
    static void Main()
    {
        Console.Write("Введите число: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            var (total, even) = CountDivisors(n);
            Console.WriteLine($"Число: {n}\nДелители: {total}, Чётные: {even}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}