using CodeTest.Interfaces;
using CodeTest.Services;

namespace CodeTest
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
