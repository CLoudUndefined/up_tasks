using System;
class Program
{
    static string RemoveDuplicates(string word)
    {
        if (string.IsNullOrEmpty(word)) throw new ArgumentException("Пустое слово");
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
    static void Main()
    {
        Console.Write("Введите слово: ");
        try
        {
            string input = Console.ReadLine() ?? "";
            string result = RemoveDuplicates(input);
            Console.WriteLine($"Слово: {input}\nРезультат: {result}");
        }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}