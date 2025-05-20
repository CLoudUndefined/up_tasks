using System;

class Program
{
    static string ReplaceSpaces(string sentence)
    {
        if (string.IsNullOrEmpty(sentence))
            throw new ArgumentException("Слово не может быть пустым");

        string result = "";
        for (int i = 0; i < sentence.Length; i++)
        {
            if (sentence[i] == ' ')
                result += '_';
            else
                result += sentence[i];
        }
        return result;
    }

    static void RunTests()
    {
        static void Test(string input, string expected, string testName, bool expectException)
        {
            try
            {
                string result = ReplaceSpaces(input);

                bool passed = !expectException && result == expected;

                Console.WriteLine($"--- Тест: {testName} ---");
                Console.WriteLine($"Входная строка: {input}");
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

        Test("Hello world test", "Hello_world_test", "Позитивный тест (предложение с пробелами)", false);
        Test("NoSpacesHere", "NoSpacesHere", "Негативный тест (без пробелов)", false);
        Test(" ", "_", "Пограничный тест (один пробел)", false);
        Test("", "", "Исключительный тест (пустая строка)", true);

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        Console.Write("Введите предложение: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            string result = ReplaceSpaces(input);
            Console.WriteLine($"Входная строка: {input}");
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