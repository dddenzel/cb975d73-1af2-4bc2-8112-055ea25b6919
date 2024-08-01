using CodeTest.Interfaces;

namespace CodeTest.Services
{
    /// <summary>
    /// Number sequencer service
    /// </summary>
    public class NumberSequencerService : INumberService
    {
        /// <summary>
        /// Finds the largest and earliest number sequence in a group of numbers
        /// </summary>
        /// <param name="numberString">A group of numbers, seperated by a single whitespace character</param>
        /// <returns>A number sequence as a string</returns>
        /// <exception cref="ArgumentException">Exception for missing numbers</exception>
        /// <exception cref="InvalidCastException">Exception for invalid numbers</exception>
        public string? FindNumberSequence(string? numberString)
        {
            string? result = null;
            List<List<int>> results = new List<List<int>>();

            if (string.IsNullOrEmpty(numberString))
                throw new ArgumentException("Missing or invalid string of numbers");

            // Split the input by a single whitespace character
            var numberStringList = numberString?.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // Ensure that all elements are valid integers. Throw an exception if not
            if (numberStringList?.Any(x => !int.TryParse(x, out var num)) ?? false)
                throw new InvalidCastException("One or more numbers are represent an invalid integer");

            // Cast the input as a list of integers
            var numbers = numberString?.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)?
                .Select(x => int.Parse(x))?.ToList() ?? new List<int>();

            // Loop through all numbers in our list and get all sequences
            results = numbers.Select((num, i) => GetSequence(numbers, i)).ToList();           

            // If we have any results            
            if (results.Any())
            {
                // First filter by only those with the highest number of entries
                results = results.Where(x => x.Count == results.Max(y => y.Count)).ToList();

                // Take the first we have found and convert to a string (there may be more than one)
                result = string.Join(" ", results.First(x => x.Count == results.Max(y => y.Count)));
            }

            return result;
        }

        /// <summary>
        /// Get number sequence from a list of numbers found after a given offset
        /// </summary>
        /// <param name="numbers">List of integers to get the sequence from</param>
        /// <param name="currentOffset">Offset to start searching from</param>
        /// <returns>Sequence of numbers</returns>
        private List<int> GetSequence(List<int> numbers, int currentOffset)
        {
            // Loop through all subsequent numbers in our list
            var sequentialList = new List<int>();
            for (int x = currentOffset; x <= numbers.Count - 1; x++)
            {
                // If the current number we are looking (if we have one) at is not greater
                // than the last, then exit out at this point
                if (sequentialList.Any() && numbers[x] <= sequentialList.Last())
                    break;

                // Otherwise, add the number to our running sequential list
                sequentialList.Add(numbers[x]);
            }

            return sequentialList;
        }
    }
}
