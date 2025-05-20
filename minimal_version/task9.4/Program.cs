using System;
class Program
{
    static void FormMaxAbsArray(int[,] a, int[] result)
    {
        if (a.GetLength(0) != 5 || a.GetLength(1) != 6 || result.Length != 6)
            throw new ArgumentException("Размер матрицы 5x6, размер массива результат — 6");
        for (int j = 0; j < 6; j++)
        {
            int maxAbs = Math.Abs(a[0, j]);
            for (int i = 1; i < 5; i++)
                if (Math.Abs(a[i, j]) > maxAbs)
                    maxAbs = Math.Abs(a[i, j]);
            result[j] = maxAbs;
        }
    }
    static void Main()
    {
        int[,] a = new int[5, 6];
        int[] result = new int[6];
        try
        {
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 6; j++)
                {
                    Console.Write($"Элемент [{i + 1},{j + 1}]: ");
                    a[i, j] = int.Parse(Console.ReadLine() ?? "");
                }
            FormMaxAbsArray(a, result);
            Console.WriteLine("Матрица: ");
            for (int i = 0; i < 5; i++)
            {
                int[] row = new int[6];
                for (int j = 0; j < 6; j++) row[j] = a[i, j];
                Console.WriteLine("[" + string.Join(", ", row) + "]");
            }
            Console.WriteLine("Результат: [" + string.Join(", ", result) + "]");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}