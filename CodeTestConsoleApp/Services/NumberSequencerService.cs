using CodeTestConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTestConsoleApp.Services
{
    public class NumberSequencerService : INumberService
    {
        public string? FindNumberSequence(string? numberString)
        {
            string? result = null;
            List<List<int>> results = new List<List<int>>();

            var numbers = numberString?.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)?
                .Select(x => int.Parse(x))?.ToList() ?? new List<int>();

            for (int i = 0; i <= numbers.Count - 1; i++)
            {
                var sequentialList = new List<int>();
                for (int x = i; x <= numbers.Count - 1; x++)
                {
                    if (sequentialList.Any() && numbers[x] <= sequentialList.Last())
                        break;

                    sequentialList.Add(numbers[x]);
                }

                results.Add(sequentialList);
            }

            if (results.Any())
                result = string.Join(" ", results.First(x => x.Count == results.Max(y => y.Count)));

            return result;
        }
    }
}
