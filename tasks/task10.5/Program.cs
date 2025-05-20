using System;

class Program
{
    static string RemoveDuplicates(string word)
    {
        if (string.IsNullOrEmpty(word))
            throw new ArgumentException("Слово не может быть пустым");

        string result = "";
        for (int i = 0; i < word.Length; i++)
        {
            bool isDuplicate = false;
            for (int j = 0; j < result.Length; j++)
            {
                if (word[i] == result[j])
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
                result += word[i];
        }
        return result;
    }

    static void RunTests()
    {
        static void Test(string input, string expected, string testName, bool expectException)
        {
            try
            {
                string result = RemoveDuplicates(input);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входное слово: {input}");
                Console.WriteLine($"Результат: {result}");
                Console.WriteLine(expectException
                    ? "❌ Не прошёл (ожидалось исключение, но его нет)"
                    : passed
                        ? "✅ Прошёл"
                        : $"❌ Не прошёл → Ожидалось: {expected}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine(expectException
                    ? $"✅ Прошёл (исключение: {ex.Message})"
                    : $"❌ Не прошёл (выброшено исключение: {ex.Message})");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test("hello", "helo", "Позитивный тест (слово с повторениями)", false);
        Test("abcd", "abcd", "Негативный тест (без повторений)", false);
        Test("a", "a", "Пограничный тест (одна буква)", false);
        Test("", "", "Исключительный тест (пустая строка)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите слово: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            string result = RemoveDuplicates(input);

            Console.WriteLine($"Входное слово: {input}");
            Console.WriteLine($"Результат: {result}");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Произошла неожиданная ошибка: {ex.Message}");
        }
    }
}