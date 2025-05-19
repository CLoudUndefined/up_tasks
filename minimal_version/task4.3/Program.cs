using System;

class Program
{
    static void ReverseArray(int[] arr)
    {
        for (int i = 0; i < arr.Length / 2; i++)
        {
            int temp = arr[i];
            arr[i] = arr[arr.Length - 1 - i];
            arr[arr.Length - 1 - i] = temp;
        }
    }

    static void Main()
    {
        Console.Write("Введите размер массива: ");
        try
        {
            int n = int.Parse(Console.ReadLine() ?? "");
            if (n <= 0) { Console.WriteLine("Размер должен быть положительным"); return; }
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Элемент {i + 1}: ");
                arr[i] = int.Parse(Console.ReadLine() ?? "");
            }
            Console.WriteLine("Массив: [" + string.Join(", ", arr) + "]");
            ReverseArray(arr);
            Console.WriteLine("Обратный массив: [" + string.Join(", ", arr) + "]");
        }
        catch (FormatException) { Console.WriteLine("Ошибка: Некорректное число"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}