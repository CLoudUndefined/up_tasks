using System;

class Program
{
    static int FindBestAthlete(int[,] A, int M, int N)
    {
        if (M < 4 || N <= 0 || A.GetLength(0) != M || A.GetLength(1) != N)
            throw new ArgumentException("Некорректные размеры или M<4");
        int maxJump = A[3, 0], best = 0;
        for (int j = 1; j < N; j++)
            if (A[3, j] > maxJump)
            {
                maxJump = A[3, j];
                best = j;
            }
        return best + 1;
    }

    static void Main()
    {
        Console.Write("Попытки M: ");
        Console.Write("Спортсмены N: ");
        try
        {
            int M = int.Parse(Console.ReadLine() ?? "");
            int N = int.Parse(Console.ReadLine() ?? "");
            if (M <= 0 || N <= 0) throw new ArgumentException("Положительные размеры");
            int[,] A = new int[M, N];
            for (int i = 0; i < M; i++)
                for (int j = 0; j < N; j++)
                {
                    Console.Write($"A[{i + 1},{j + 1}]: ");
                    A[i, j] = int.Parse(Console.ReadLine() ?? "");
                }
            int result = FindBestAthlete(A, M, N);
            Console.WriteLine("Таблица:");
            for (int i = 0; i < M; i++)
            {
                int[] row = new int[N];
                for (int j = 0; j < N; j++) row[j] = A[i, j];
                Console.WriteLine($"[{string.Join(", ", row)}]");
            }
            Console.WriteLine($"Результат: {result}");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}