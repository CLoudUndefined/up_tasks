using System;
class Program
{
    static int SumDecade(int[] arr, int start, int count)
    {
        int sum = 0;
        for (int i = start; i < start + count; i++)
        {
            if (arr[i] < 0) throw new ArgumentException($"Отрицательное значение в день {i + 1}");
            sum += arr[i];
        }
        return sum;
    }
    static void Main()
    {
        int[] rainfall = new int[30];
        try
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write($"День {i + 1}: ");
                string input = Console.ReadLine() ?? "";
                if (!int.TryParse(input, out int value)) throw new FormatException("Введено не число. Пожалуйста, введите целое число.");
                rainfall[i] = value;
            }
            Console.WriteLine($"1-я декада: {SumDecade(rainfall, 0, 10)} мм");
            Console.WriteLine($"2-я декада: {SumDecade(rainfall, 10, 10)} мм");
            Console.WriteLine($"3-я декада: {SumDecade(rainfall, 20, 10)} мм");
        }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}