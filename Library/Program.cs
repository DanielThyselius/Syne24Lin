// See https://aka.ms/new-console-template for more information
namespace Library;
using System;


class Program
{
    static void Main(string[] args)
    {
        var exit = false;
        var analyzer = new TextAnalyzer();
        var library = new LibrarySystem();

        var packageHandler = new PackageHandler();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Library Booking System\n");
            Console.WriteLine("1. Exit program");
            Console.WriteLine("2. Analyze Text");
            Console.WriteLine("3. List resources");
            Console.WriteLine("4. Find resource");
            Console.WriteLine("5. Book a resource");
            Console.WriteLine("6. Calculate Package Price");

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
                    Console.WriteLine("Resources:");
                    library.Resources.ForEach(
                        r => Console.WriteLine($"{r.Id}: {r.Name}")
                        );

                    break;

                case "4":
                    Console.Write("Enter resource name: ");
                    var resourceName = Console.ReadLine();
                    var resource = library.GetResource(resourceName);
                    if (resource == null)
                    {
                        Console.WriteLine("Resource not found.");
                        break;
                    }

                    Console.WriteLine($"Resource found: {resource.Id}: {resource.Name}");
                    break;

                case "5":
                    Console.Write("Enter resource id: ");
                    var resourceId = int.Parse(Console.ReadLine());
                    Console.Write("Enter your name: ");
                    var userName = Console.ReadLine();

                    var success = library.BookResource(resourceId, userName);

                    Console.WriteLine(
                        success ? "Resource booked!"
                        : "Resource not found or could not be booked."
                        );
                    break;


                case "6":
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
