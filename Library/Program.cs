// See https://aka.ms/new-console-template for more information
using System;


class Program
{
    static void Main(string[] args)
    {
        var exit = false;
        var analyzer = new TextAnalyzer();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Library Booking System\n");
            Console.WriteLine("1. Exit program");
            Console.WriteLine("2. Analyze Text");
            Console.Write("Select an option: ");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    exit = true;
                    break;
                case "2":
                    Console.Write("Enter text to analyze: ");
                    var text = Console.ReadLine();
                    Console.WriteLine($"Word Count: {analyzer.CountWords(text)}");
                    Console.WriteLine($"Letter Count: {analyzer.CountLetters(text)}");
                    break;
                default:
                    Console.WriteLine("Invalid selection, please try again.");
                    break;
            }

            if (!exit)
            {
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
