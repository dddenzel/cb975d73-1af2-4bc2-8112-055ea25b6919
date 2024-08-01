using CodeTest.Interfaces;
using CodeTest.Services;
using CodeTest.Testing.Model;
using Moq;
using Newtonsoft.Json;

namespace CodeTest.Testing
{
    /// <summary>
    /// Base test class
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// Mock repository
        /// </summary>
        protected MockRepository _mockRepository;

        /// <summary>
        /// Mock number service
        /// </summary>
        protected Mock<INumberService> _mockNumberService;
        


        /// <summary>
        /// Constructor
        /// </summary>
        public BaseTest()
        {
            // Normally for testing I would be using Moq or RhinoMocks.
            // I would initialze things here in a base class as follows, but no actual need
            // to use them for such simple coding examples

            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockNumberService = _mockRepository.Create<INumberService>();
        }

        /// <summary>
        /// Test test case data
        /// </summary>
        /// <param name="data">Test case data</param>
        /// <returns>True if test case data matches expected output</returns>
        protected bool TestTestCaseData(TestCaseData data)
        {
            var numberSequencer = new NumberSequencerService();            
            var result = numberSequencer.FindNumberSequence(string.Join(" ", data.InputData));
            return result?.Equals(string.Join(" ", data.OutputData)) ?? false;
        }

        #region Helpers

        /// <summary>
        /// Get test case data from embedded resources
        /// </summary>
        /// <param name="resourceName">Test case file name</param>
        /// <returns>Test case data</returns>
        /// <exception cref="Exception">Exception if file not found</exception>
        protected TestCaseData GetTestCaseData(string resourceName)
        {
            TestCaseData? result = null;
            var assemblyResourceName = this.GetType().Assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));

            if (assemblyResourceName == null)
                throw new FileNotFoundException("Could not find resource {resourceName} in current assembly");

            var stream = this.GetType().Assembly.GetManifestResourceStream(assemblyResourceName);

            if (stream != null)
                using (StreamReader sr = new StreamReader(stream))
                    result = JsonConvert.DeserializeObject<TestCaseData>(sr.ReadToEnd());

            return result ?? new TestCaseData();
        }

        #endregion

    }
}
