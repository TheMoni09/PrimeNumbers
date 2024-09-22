using System;
using System.Diagnostics;

namespace PrimeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string? userInput;
            int limit = 0;
            bool isInfinite = false;

            while (true)
            {
                Console.Write("What's the limit you want? (or type 'none' for no limit): ");
                userInput = Console.ReadLine();

                if (userInput != null && userInput.ToLower() == "none")
                {
                    isInfinite = true;
                    break;
                }

                if (userInput != null && Int32.TryParse(userInput, out limit))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid input!");
                }
            }

            Console.WriteLine(isInfinite ? "No limit set!" : $"Limit set to {limit}!");

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                int number = 0;

                while (true)
                {
                    number++;

                    if (!isInfinite && number > limit) break;

                    if (IsPrime(number))
                    {
                        Console.WriteLine(number);
                    }
                }
            }
            finally
            {
                stopwatch.Stop();
                Console.WriteLine($"Time taken: {stopwatch.Elapsed}");
            }
        }

        static bool IsPrime(int number)
        {
            if (number < 2) return false;

            for (int i = 2; i * i <= number; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
