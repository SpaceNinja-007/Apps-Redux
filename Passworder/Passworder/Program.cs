using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("🔐 Password Generator");

        Console.Write("Length of password: ");
        if (!int.TryParse(Console.ReadLine(), out int length) || length < 1)
        {
            Console.WriteLine("❌ Invalid length.");
            return;
        }

        Console.Write("Include letters (y/n)? ");
        bool useLetters = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Include numbers (y/n)? ");
        bool useNumbers = Console.ReadLine()?.ToLower() == "y";

        Console.Write("Include symbols (y/n)? ");
        bool useSymbols = Console.ReadLine()?.ToLower() == "y";

        string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numbers = "0123456789";
        string symbols = "!@#$%^&*()-_=+<>?";

        string pool = "";

        if (useLetters) pool += letters;
        if (useNumbers) pool += numbers;
        if (useSymbols) pool += symbols;

        if (string.IsNullOrEmpty(pool))
        {
            Console.WriteLine("❌ No character types selected.");
            return;
        }

        var rand = new Random();
        var password = new StringBuilder();

        for (int i = 0; i < length; i++)
        {
            int index = rand.Next(pool.Length);
            password.Append(pool[index]);
        }

        Console.WriteLine($"\n🎉 Your generated password:\n{password}");
    }
}
