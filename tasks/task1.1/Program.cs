using System;

class Program
{
    static double CalculateTax(double income)
    {
        if (income <= 1000)
            return 0;
        else if (income <= 5000)
            return (income - 1000) * 0.1;
        else if (income <= 10000)
            return 500 + (income - 5000) * 0.2;
        else
            return 1000 + (income - 10000) * 0.3;
    }

    static void RunTests()
    {
        void Test(double income, double expected, string testName)
        {
            try
            {
                if (income < 0)
                    throw new ArgumentException("Доход не может быть отрицательным");
                double tax = CalculateTax(income);
                string result = tax == expected ? "✅ Прошёл" : $"❌ НЕ ПРОШЁЛ (ожидалось: {expected})";
                Console.WriteLine($"{testName}: Доход: {income} → Налог: {tax} → {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{testName}: Доход: {income} → Ошибка: {ex.Message}");
            }
        }

        Console.WriteLine("=== ТЕСТЫ для тестов ^-^ ===");

        Test(800, 0, "Стандартный 800");
        Test(3000, 200, "Стандартный 3000");
        Test(7000, 900, "Стандартный 7000");
        Test(15000, 2500, "Стандартный 15000");
        Test(1000, 0, "Пограничный 1000");
        Test(1001, 0.1, "Пограничный 1001");
        Test(5000, 400, "Пограничный 5000");
        Test(5001, 500.2, "Пограничный 5001");
        Test(10000, 1500, "Пограничный 10000");
        Test(10001, 1000.3, "Пограничный 10001");
        Test(-100, -1, "Отрицательный -100");
        Test(10000000000, 2999998000, "Большой 10000000000");

        Console.WriteLine("========== Закончили ==========");
    }

    static void Main()
    {
        RunTests();

        // Конструкция ?? нужна, чтобы не возникала ошибка:
        // CS8600: Converting null literal or possible null value to non-nullable type
        // Так что он тут необходим для лакончиности. Ничего страшного, надеюсь? :<
        // В других заданиях этот оператор тоже можно будет увидеть
        Console.Write("Введите сумму месячного дохода: ");
        string input = Console.ReadLine() ?? "";

        try
        {
            double income = double.Parse(input);

            if (income < 0)
                throw new ArgumentException("Доход не может быть отрицательным");

            double tax = CalculateTax(income);
            Console.WriteLine($"Величина месячного подоходного налога: {tax} у.е.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Ошибка: Введено некорректное значение. Пожалуйста, введите число.");
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