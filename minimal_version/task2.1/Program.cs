using System;

class Program
{
    static bool CheckDifference(double max, double min) => (max - min) <= 25;
    static bool CheckRatio(double max, double min) => min != 0 && max / min > 2;

    static void Main()
    {
        Console.Write("Количество чисел: ");
        int n = int.Parse(Console.ReadLine() ?? "");
        if (n <= 0) { Console.WriteLine("Положительное число!"); return; }

        double min = 0, max = 0;
        try
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Число {i + 1}: ");
                double num = double.Parse(Console.ReadLine() ?? "");
                if (i == 0) min = max = num;
                else { if (num < min) min = num; if (num > max) max = num; }
            }
            Console.WriteLine($"Мин: {min}\nМакс: {max}");
            Console.WriteLine($"Условие а): {CheckDifference(max, min)}");
            Console.WriteLine($"Условие б): {CheckRatio(max, min)}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}