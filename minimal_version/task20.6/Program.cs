using System;

class Program
{
    static int[] RemoveValue(int[] X, int P)
    {
        if (X.Length == 0) throw new ArgumentException("Пустой массив");
        for (int i = 1; i < X.Length; i++)
            if (X[i] < X[i - 1]) throw new ArgumentException("Неупорядоченный массив");
        int left = 0, right = X.Length - 1, leftBound = -1, rightBound = -1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (X[mid] == P) { leftBound = mid; right = mid - 1; }
            else if (X[mid] < P) left = mid + 1;
            else right = mid - 1;
        }
        left = 0; right = X.Length - 1;
        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (X[mid] == P) { rightBound = mid; left = mid + 1; }
            else if (X[mid] < P) left = mid + 1;
            else right = mid - 1;
        }
        if (leftBound == -1) return (int[])X.Clone();
        int[] result = new int[X.Length - (rightBound - leftBound + 1)];
        int index = 0;
        for (int i = 0; i < leftBound; i++) result[index++] = X[i];
        for (int i = rightBound + 1; i < X.Length; i++) result[index++] = X[i];
        return result;
    }

    static void Main()
    {
        Console.Write("Длина массива: ");
        Console.Write("Значение P: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            int P = int.Parse(Console.ReadLine() ?? "");
            if (n <= 0) throw new ArgumentException("Положительная длина");
            int[] X = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"X[{i}]: ");
                X[i] = int.Parse(Console.ReadLine() ?? "");
            }
            int[] result = RemoveValue(X, P);
            Console.WriteLine($"X: [{string.Join(", ", X)}]\nP: {P}\nРезультат: [{string.Join(", ", result)}]");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}