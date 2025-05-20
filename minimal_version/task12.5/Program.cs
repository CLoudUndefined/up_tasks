using System;
class Program
{
    static string ReplaceSpaces(string sentence)
    {
        if (string.IsNullOrEmpty(sentence)) throw new ArgumentException("Пустая строка");
        string result = "";
        for (int i = 0; i < sentence.Length; i++)
        {
            char c = sentence[i];
            result += c == ' ' ? '_' : c;
        }
        return result;
    }
    static void Main()
    {
        Console.Write("Введите предложение: ");
        try
        {
            string input = Console.ReadLine() ?? "";
            string result = ReplaceSpaces(input);
            Console.WriteLine($"Строка: {input}\nРезультат: {result}");
        }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}