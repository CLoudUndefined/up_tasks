using System;

class Program
{
    static int Gcd(int a, int b)
    {
        while (b != 0) { int temp = b; b = a % b; a = temp; }
        return a;
    }

    static void Main()
    {
        Console.WriteLine("Несократимые дроби (0 < x < 1, знаменатель ≤ 7):");
        for (int d = 2; d <= 7; d++)
            for (int n = 1; n < d; n++)
                if (Gcd(n, d) == 1)
                    Console.WriteLine($"{n}/{d}");
    }
}