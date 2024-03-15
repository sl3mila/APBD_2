// See https://aka.ms/new-console-template for more information
int[] arr = new[] { 1, 2, 3, 4, 5 };

Console.WriteLine("Hello,, World!!");;
Console.WriteLine(GetAvg(arr));

static double GetAvg(int[] arr)
{
    int total = 0;
    foreach (var num in arr)
    {
        total += num;
    }

    return (double)total / arr.Length;
}

