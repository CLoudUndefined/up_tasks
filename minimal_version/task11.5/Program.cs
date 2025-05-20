using System;
class Program
{
    static int CountDigitsAndSigns(string s)
    {
        if (string.IsNullOrEmpty(s)) throw new ArgumentException("Пустая строка");
        int count = 0;
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (char.IsDigit(c) || c == '+' || c == '-' || c == '*')
                count++;
        }
        return count;
    }
    static void Main()
    {
        Console.Write("Введите строку: ");
        try
        {
            string input = Console.ReadLine() ?? "";
            int result = CountDigitsAndSigns(input);
            Console.WriteLine($"Строка: {input}\nРезультат: {result}");
        }
        catch (ArgumentException ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
        catch (Exception ex) { Console.WriteLine($"Ошибка: {ex.Message}"); }
    }
}