using System;
using System.IO;
using System.Threading.Tasks;

public class BackgroundOperation
{
    // Function to write in file
    public async Task WriteToFileAsync(string message)
    {
        await Task.Delay(3000);
        await File.WriteAllTextAsync("../../../tmp.txt", message);
    }
}

class Program
{
    static async Task Main(string[] args)
    {

        while (true)
        {
            // Kiosk system menu
            Console.WriteLine("Kiosk System Menu:");
            Console.WriteLine("1. Write \"Hello World\"");
            Console.WriteLine("2. Write Current Date");
            Console.WriteLine("3. Write OS Version");
            Console.WriteLine("Enter your choice (1/2/3):");

            // User choice
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    await WriteToFileAsync("Hello World");
                    break;
                case "2":
                    await WriteToFileAsync(DateTime.Now.ToString());
                    break;
                case "3":
                    await WriteToFileAsync(Environment.OSVersion.VersionString);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                    break;
            }
        }
    }

    // Function to call write in file function
    static async Task WriteToFileAsync(string message)
    {
        BackgroundOperation backgroundOperation = new BackgroundOperation();
        Console.WriteLine("Writing to file...");
        await backgroundOperation.WriteToFileAsync(message);
        Console.WriteLine("Write operation completed.");
    }
}
