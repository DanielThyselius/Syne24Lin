using System;

var test = new String[5];
var numbers = new int[] { 1, 2, 3, 4, 5, 6, 8, 14, 15, 22, 23 };
//ReverseInput(test);

var max = GetMax(numbers);
Console.WriteLine("Max value in numbers: " + max);

Console.WriteLine("What number would you like to find?");
var target = int.Parse(Console.ReadLine());
var targetIndex = BinarySearch(numbers, target);
Console.WriteLine("Target found at: " + targetIndex);



Console.WriteLine("Press any key to exit...");
Console.ReadKey();

static int BinarySearch(int[] numbers, int target)
{
    var L = 0;
    var R = numbers.Length - 1;
    while (L <= R)
    {
        var N = (L + R) / 2;
        if (numbers[N] == target)
            return N;

        if (numbers[N] < target)
        {
            L = N + 1;
        }
        else
        {
            R = N -1;
        }
    };

    return -1;
}

static int? GetIndexOfNumber(int[] numbers, int key)
{
    for (int i = 0; i < numbers.Length; i++)
    {
        if (key == numbers[i])
            return i;
    }

    return null;
}

static int GetMax(int[] numbers)
{
    var max = 0;
    foreach (var item in numbers)
    {
        if (item > max)
            max = item;
    }
    return max;
}
static void ReverseInput(string[] test)
{
    for (int i = 0; i < test.Length; i++)
    {
        test[i] = Console.ReadKey().KeyChar.ToString();
    }
    Console.WriteLine("Backwards that is: ");

    for (int i = test.Length - 1; i >= 0; i--)
    {
        Console.Write(test[i]);
    }
}