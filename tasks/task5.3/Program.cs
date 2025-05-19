using System;

class Program
{
    static void FillArrayWithRandomHeights(int[] arr, int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rand.Next(min, max + 1); // max включительно тут >.>
        }
    }

    static void PrintArray(int[] arr, string message)
    {
        Console.WriteLine(message);
        Console.WriteLine("[" + string.Join(", ", arr) + "]");
    }

    static void RunTests()
    {
        void Test(int[] arr, int min, int max, string testName)
        {
            Console.WriteLine($"--- Тест: {testName} ---");
            FillArrayWithRandomHeights(arr, min, max);

            bool passed = true;
            foreach (int value in arr)
            {
                if (value < min || value > max)
                {
                    passed = false;
                    break;
                }
            }

            Console.WriteLine("Результат: [" + string.Join(", ", arr) + "]");
            Console.WriteLine(passed ? "✅ Прошёл" : "❌ Не прошёл → значение вне диапазона");
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(new int[12], 163, 190, "Основной тест (диапазон 163–190)");
        Test(new int[5], 0, 10, "Тест с другим диапазоном");
        Test(new int[0], 100, 200, "Пустой массив");
        Test(new int[1], -10, 5, "Минусовые значения");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        const int n = 12;
        const int minHeight = 163;
        const int maxHeight = 190;

        int[] heights = new int[n];

        FillArrayWithRandomHeights(heights, minHeight, maxHeight);

        PrintArray(heights, "Массив со случайными ростами:");
    }
}