using System;
class Program
{
    static void SwapRows(int[,] a, int n)
    {
        if (n <= 0 || a.GetLength(0) != n || a.GetLength(1) != n) 
            throw new ArgumentException("Квадратная таблица с n > 0");
        for (int i = 0; i < n - 1; i += 2)
            for (int j = 0; j < n; j++)
            {
                int temp = a[i, j];
                a[i, j] = a[i + 1, j];
                a[i + 1, j] = temp;
            }
    }
    static void Main()
    {
        Console.Write("Размер таблицы: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            if (n <= 0) throw new ArgumentException("Положительный размер");
            int[,] a = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    a[i, j] = int.Parse(Console.ReadLine() ?? "");
                }
            Console.WriteLine("Исходная:");
            for (int i = 0; i < n; i++)
            {
                int[] row = new int[n];
                for (int j = 0; j < n; j++) row[j] = a[i, j];
                Console.WriteLine("[" + string.Join(", ", row) + "]");
            }
            SwapRows(a, n);
            Console.WriteLine("После обмена:");
            for (int i = 0; i < n; i++)
            {
                int[] row = new int[n];
                for (int j = 0; j < n; j++) row[j] = a[i, j];
                Console.WriteLine("[" + string.Join(", ", row) + "]");
            }
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}