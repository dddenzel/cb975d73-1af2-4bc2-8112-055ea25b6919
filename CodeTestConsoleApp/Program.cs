using CodeTestConsoleApp.Interfaces;
using CodeTestConsoleApp.Services;

namespace CodeTestConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            INumberService sequencerService = new NumberSequencerService();

            var result = sequencerService.FindNumberSequence("6 1 5 9 2");
        }
    }
}
