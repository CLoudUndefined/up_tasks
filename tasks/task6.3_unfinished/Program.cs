using System;

class Program
{
    static void InputRainfall(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"Введите количество осадков за {i + 1} июня: ");
            arr[i] = int.Parse(Console.ReadLine() ?? "0");
        }
    }

    static int SumDecade(int[] arr, int startDay, int daysCount)
    {
        int sum = 0;
        for (int i = startDay; i < startDay + daysCount && i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static void RunTests()
    {
        void Test(int[] input, int start, int count, int expected, string testName)
        {
            int result = SumDecade(input, start, count);
            bool passed = result == expected;
            Console.WriteLine($"{testName}: [{string.Join(", ", input)}], начиная с {start}, {count} дней → Результат: {result} → {(passed ? "✅ Прошёл" : $"❌ Не прошёл (ожидалось: {expected})")}");
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(new int[30], 0, 10, 0, "Пустой массив");
        Test(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 0, 10, 55, "Массив из 10 элементов");
        Test(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 }, 10, 1, 11, "Один элемент третьей декады");
        Test(new int[] { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 }, 0, 30, 150, "Все пять");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        const int daysInJune = 30;
        int[] rainfall = new int[daysInJune];

        Console.WriteLine("Введите количество осадков за каждый день июня:");
        InputRainfall(rainfall);

        int decade1 = SumDecade(rainfall, 0, 10);
        int decade2 = SumDecade(rainfall, 10, 10);
        int decade3 = SumDecade(rainfall, 20, 10);

        Console.WriteLine("\nОбщее количество осадков:");
        Console.WriteLine($"Первая декада: {decade1} мм");
        Console.WriteLine($"Вторая декада: {decade2} мм");
        Console.WriteLine($"Третья декада: {decade3} мм");
    }
}