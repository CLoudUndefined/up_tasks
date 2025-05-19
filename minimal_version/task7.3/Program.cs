using System;
class Program
{
    static void FormArrayQ(int[] P, int[] Q)
    {
        if (P.Length != Q.Length) throw new ArgumentException("Одинаковый размер массивов");
        for (int i = 0; i < P.Length; i++)
            Q[i] = (i >= 2 && i <= 9) ? -P[i] : P[i] * i;
    }
    static void Main()
    {
        Console.Write("Размер массива: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            if (n <= 0) throw new ArgumentException("Положительный размер");
            int[] P = new int[n], Q = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                P[i] = int.Parse(Console.ReadLine() ?? "");
            }
            FormArrayQ(P, Q);
            Console.WriteLine("P: [" + string.Join(", ", P) + "]");
            Console.WriteLine("Q: [" + string.Join(", ", Q) + "]");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}