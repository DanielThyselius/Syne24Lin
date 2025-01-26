// See https://aka.ms/new-console-template for more information
namespace Library;
using System;

class Program
{
    static void Main(string[] args)
    {
        var exit = false;
        var analyzer = new TextAnalyzer();
        var packageHandler = new PackageHandler();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Library Booking System\n");
            Console.WriteLine("1. Exit program");
            Console.WriteLine("2. Analyze Text");
            Console.WriteLine("3. Calculate Package Price");
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
                case "3":
                    Console.WriteLine("Select package type:");
                    Console.WriteLine("1. Cylinder");
                    Console.WriteLine("2. Box");
                    var packageType = Console.ReadLine();

                    switch (packageType)
                    {
                        case "1":
                            // TODO: Create a Cylinder object and calculate the price
                            break;
                        case "2":
                            // TODO: Create a Box object and calculate the price
                            break;
                        default:
                            Console.WriteLine("Invalid package type selection.");
                            break;
                    }
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
