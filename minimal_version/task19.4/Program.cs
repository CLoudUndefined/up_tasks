using System;

class Program
{
    static int[,] InsertZeroRows(int[,] A)
    {
        if (A.GetLength(0) != 5 || A.GetLength(1) != 8) throw new ArgumentException("Размер 5x8");
        int rowsToInsert = 0;
        for (int i = 0; i < 5; i++)
            if (A[i, 0] % 3 == 0) rowsToInsert++;
        int[,] result = new int[5 + rowsToInsert, 8];
        int currentRow = 0;
        for (int i = 0; i < 5; i++)
        {
            if (A[i, 0] % 3 == 0)
            {
                for (int j = 0; j < 8; j++) result[currentRow, j] = 0;
                currentRow++;
            }
            for (int j = 0; j < 8; j++) result[currentRow, j] = A[i, j];
            currentRow++;
        }
        return result;
    }

    static void Main()
    {
        int[,] A = new int[5, 8];
        Random rand = new Random();
        for (int i = 0; i < 5; i++)
            for (int j = 0; j < 8; j++)
                A[i, j] = rand.Next(1, 101);
        try
        {
            Console.WriteLine("Массив:");
            for (int i = 0; i < 5; i++)
                Console.WriteLine($"[{string.Join(", ", Enumerable.Range(0, 8).Select(j => A[i, j]))}]");
            int[,] result = InsertZeroRows(A);
            Console.WriteLine("Результат:");
            for (int i = 0; i < result.GetLength(0); i++)
                Console.WriteLine($"[{string.Join(", ", Enumerable.Range(0, 8).Select(j => result[i, j]))}]");
        }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}