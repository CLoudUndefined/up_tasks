using System;
class Program
{
    static void PrintSquares(int n)
    {
        if (n < 0) throw new ArgumentException("Неотрицательное число");
        int square = 0, diff = 1;
        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine($"{i}² = {square}");
            diff += 2;
            square += diff - 2;
        }
    }
    static void Main()
    {
        Console.Write("Введите n: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            PrintSquares(n);
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}