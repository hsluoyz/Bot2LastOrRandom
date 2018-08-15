using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot2LastOrRandom
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read input from stdin
            var history = new List<string[]>();
            while (true)
            {
                // Each line is the history for one round
                var roundLine = Console.In.ReadLine();
                if (string.IsNullOrEmpty(roundLine))
                {
                    break;
                }

                // The first value is golden number for this round
                // The 2N and 2N+1 are the values from player N
                // If the value is 0, means this value invalid
                var results = roundLine.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                history.Add(results);
            }

            // This bot example will just return the golden number of the latest round.
            // The first value in last line is the golden number for the latest round.
            double number1 = ConvertToDouble(history.LastOrDefault()?.FirstOrDefault());
            double number2 = ConvertToDouble(history.LastOrDefault()?.FirstOrDefault());

            Random random = new Random(System.Diagnostics.Process.GetCurrentProcess().Id);
            if (number1 == 0d)
            {
                number1 = random.NextDouble() * 100;
            }

            if (number2 == 0d)
            {
                number2 = random.NextDouble() * 100;
            }

            // Write 2 numbers to stdout
            Console.Out.WriteLine($"{number1}\t{number2}");
        }

        private static double ConvertToDouble(string str)
        {
            try
            {
                return double.Parse(str);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Convert \"{str}\" to double failed: {ex.Message}");
                return 0d;
            }
        }
    }
}
