using CodeTest.Interfaces;
using CodeTest.Services;

namespace CodeTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // If no arguments or a call for help, show usage
            if (args.Length == 0 || new[] { "/h", "--h", "/help", "--help" }.Contains(args[0], StringComparer.OrdinalIgnoreCase))
                ShowUsage();

            if (args.Length == 1)
            {
                INumberService sequencerService = new NumberSequencerService();
                var result = sequencerService.FindNumberSequence(args[1]);
                Console.WriteLine(result);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// Show usage on console
        /// </summary>        
        private static void ShowUsage()
        {
            Console.WriteLine("Usage:           CodeTest \"[num1] [num2] ...\"");            
            Console.WriteLine("Example:         CodeTest \"1 2 45 987 0 67\"");
            Console.WriteLine("");
            Console.WriteLine("Input:");
            Console.WriteLine("[num1] [num2]:   A single or list of numbers seperated by a single space");

        }
    }
}
