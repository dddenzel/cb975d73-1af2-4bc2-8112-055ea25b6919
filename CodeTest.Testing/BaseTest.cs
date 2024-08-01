using CodeTest.Interfaces;
using CodeTest.Services;
using CodeTest.Testing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeTest.Testing
{
    public class BaseTest
    {
        protected Mock<INumberService> _mockNumberService;
        protected MockRepository _mockRepository;


        public BaseTest()
        {
            // Normally for testing I would be using Moq or RhinoMocks.
            // I would initialze things here in a base class as follows, but no actual need
            // to use them for such simple coding examples

            _mockRepository = new MockRepository(MockBehavior.Default);
            _mockNumberService = _mockRepository.Create<INumberService>();
        }

        protected void TestTestCaseData(TestCaseData data)
        {
            var numberSequencer = new NumberSequencerService();
            var result = numberSequencer.FindNumberSequence(string.Join(" ", data.InputData));
            Assert.IsTrue(result.Equals(string.Join(" ", data.OutputData)));
        }

        #region Helpers

        protected TestCaseData GetTestCaseData(string resourceName)
        {
            TestCaseData result;
            var assemblyResourceName = this.GetType().Assembly.GetManifestResourceNames()
                .FirstOrDefault(x => x.EndsWith(resourceName, StringComparison.OrdinalIgnoreCase));

            if (assemblyResourceName == null)
                throw new Exception("Could not find resource {resourceName} in current assembly");

            using (StreamReader sr = new StreamReader(this.GetType().Assembly.GetManifestResourceStream(assemblyResourceName)))
                result = JsonConvert.DeserializeObject<TestCaseData>(sr.ReadToEnd());

            return result;
        }

        #endregion

    }
}
