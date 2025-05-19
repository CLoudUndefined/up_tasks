using System;
class Program
{
    static void FillArrayWithRandomHeights(int[] arr, int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
            arr[i] = rand.Next(min, max + 1);
    }
    static void Main()
    {
        const int n = 12, minHeight = 163, maxHeight = 190;
        int[] heights = new int[n];
        FillArrayWithRandomHeights(heights, minHeight, maxHeight);
        Console.WriteLine("Рост: [" + string.Join(", ", heights) + "]");
    }
}