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

            double n = 0;
            if (history.Count == 0)
            {
                Random random = new Random(System.Diagnostics.Process.GetCurrentProcess().Id);
                n = random.NextDouble() * 100;
            }
            else
            {
                for (int i = 0; i < history.Count; i++)
                {
                    n += ConvertToDouble(history[i].FirstOrDefault());
                }

                n /= history.Count;
            }

            double number1 = n - 10;
            double number2 = n + 10;

            if (number1 <= 0)
                number1 = 0.00000001;
            if (number1 >= 100)
                number1 = 99.9999999;
            if (number2 <= 0)
                number2 = 0.00000001;
            if (number2 >= 100)
                number2 = 99.9999999;

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
