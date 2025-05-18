using System;

class Program
{
    // Функция для нахождения наибольшего общего делителя (алгоритм Евклида)
    static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    static void RunTests()
    {
        void Test(int numerator, int denominator, int expectedGcd, string testName)
        {
            int result = Gcd(numerator, denominator);
            bool passed = (result == expectedGcd);
            Console.WriteLine($"{testName}: {numerator}/{denominator} → НОД = {result} → {(passed ? "✅ Прошёл" : $"❌ Не прошёл (ожидалось: {expectedGcd})")}");
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(2, 4, 2, "НОД(2,4)");
        Test(3, 7, 1, "НОД(3,7)");
        Test(6, 4, 2, "НОД(6,4)");
        Test(5, 5, 5, "НОД(5,5)");
        Test(1, 2, 1, "НОД(1,2)");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.WriteLine("Простые несократимые дроби между 0 и 1 (знаменатель ≤ 7):");

        for (int denominator = 2; denominator <= 7; denominator++)
        {
            for (int numerator = 1; numerator < denominator; numerator++)
            {
                if (Gcd(numerator, denominator) == 1)
                {
                    Console.WriteLine($"{numerator}/{denominator}");
                }
            }
        }
    }
}