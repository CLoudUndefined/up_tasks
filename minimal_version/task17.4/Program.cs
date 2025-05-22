using System;

class Program
{
    static int ScalarProduct(int[] A, int[] B)
    {
        if (A.Length != B.Length || A.Length == 0) throw new ArgumentException("Одинаковая длина, непустые");
        int result = 0;
        for (int i = 0; i < A.Length; i++) result += A[i] * B[i];
        return result;
    }

    static void Main()
    {
        Console.Write("Длина массивов: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            if (n <= 0) throw new ArgumentException("Положительная длина");
            int[] A = new int[n], B = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"A[{i}]: ");
                A[i] = int.Parse(Console.ReadLine() ?? "");
            }
            for (int i = 0; i < n; i++)
            {
                Console.Write($"B[{i}]: ");
                B[i] = int.Parse(Console.ReadLine() ?? "");
            }
            int result = ScalarProduct(A, B);
            Console.WriteLine($"A: [{string.Join(", ", A)}]\nB: [{string.Join(", ", B)}]\nРезультат: {result}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}