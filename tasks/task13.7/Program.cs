using System;

class Program
{
    static void PrintSquares(int n)
    {
        if (n < 0)
            throw new ArgumentException("Число должно быть неотрицательным");
        
        int square = 0;
        int diff = 1;
        
        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine($"{i}² = {square}");

            diff += 2;
            square += diff - 2;
        }
    }

    static void RunTests()
    {
        static void Test(int input, string[] expected, string testName, bool expectException)
        {
            try
            {
                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входное число: {input}");
                
                System.IO.StringWriter sw = new System.IO.StringWriter();
                Console.SetOut(sw);
                
                PrintSquares(input);
                
                string result = sw.ToString();
                Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
                
                Console.WriteLine($"Результат:");
                Console.WriteLine(result);
                
                if (expectException)
                {
                    Console.WriteLine("❌ Не прошёл (ожидалось исключение, но его нет)");
                    return;
                }
                
                string[] lines = result.Trim().Split('\n');
                bool passed = true;
                
                if (lines.Length != expected.Length)
                {
                    passed = false;
                }
                else
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        if (lines[i].Trim() != expected[i].Trim())
                        {
                            passed = false;
                            break;
                        }
                    }
                }
                
                Console.WriteLine(passed
                    ? "✅ Прошёл"
                    : $"❌ Не прошёл → Ожидалось: {string.Join(", ", expected)}");
            }
            catch (ArgumentException ex)
            {
                Console.SetOut(new System.IO.StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(5, new string[] 
        { 
            "0² = 0", 
            "1² = 1", 
            "2² = 4", 
            "3² = 9", 
            "4² = 16", 
            "5² = 25" 
        }, "Позитивный тест (n = 5)", false);
        Test(0, new string[] { "0² = 0" }, "Негативный тест (n = 0)", false);
        Test(1, new string[] { "0² = 0", "1² = 1" }, "Пограничный тест (n = 1)", false);
        Test(-1, new string[] { }, "Исключительный тест (отрицательное число)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите натуральное число n: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            if (!int.TryParse(input, out int n))
                throw new FormatException("Введено не число. Пожалуйста, введите целое число.");

            PrintSquares(n);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
        }
    }
}