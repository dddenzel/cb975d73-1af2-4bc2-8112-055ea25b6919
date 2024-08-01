using CodeTest.Interfaces;
using CodeTest.Services;
using CodeTest.Testing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeTest.Testing
{
    [TestClass]
    public class TestNumberService : BaseTest
    {
        #region Test validation

        [TestMethod]
        public void TestNullThrowsException()
        {
            INumberService numberService = new NumberSequencerService();

            // Set up some bad data
            string badData = null;

            // Pass in some bad data and assert the expected exception type is thrown
            Assert.ThrowsException<ArgumentException>(() => numberService.FindNumberSequence(badData));
        }

        [TestMethod]
        public void TestEmtpyStringThrowsException()
        {
            INumberService numberService = new NumberSequencerService();

            // Set up some bad data
            string badData = "";

            // Pass in some bad data and assert the expected exception type is thrown
            Assert.ThrowsException<ArgumentException>(() => numberService.FindNumberSequence(badData));
        }

        [TestMethod]
        public void TestBadDataThrowsException()
        {            
            INumberService numberService = new NumberSequencerService();

            // Set up some bad data
            string badData = "3 4 5 1 2 *";

            // Pass in some bad data and assert the expected exception type is thrown
            Assert.ThrowsException<InvalidCastException>(() => numberService.FindNumberSequence(badData));            
        }

        #endregion

        #region Test some basic permutations

        [TestMethod]
        public void TestSequenceAtStart()
        {
            INumberService numberService = new NumberSequencerService();
            TestCaseData testCaseData = new TestCaseData();

            // Set up a sequence at the start
            testCaseData.InputData = new[] { 1, 0, 0 }.ToList();
            testCaseData.OutputData = new[] { 1 }.ToList();

            // Assert the correct sequence is found
            Assert.IsTrue(TestTestCaseData(testCaseData));
        }

        [TestMethod]
        public void TestSequenceInMiddle()
        {
            INumberService numberService = new NumberSequencerService();
            TestCaseData testCaseData = new TestCaseData();

            // Set up a sequence at the start
            testCaseData.InputData = new[] { 9, 1, 2, 0 }.ToList();
            testCaseData.OutputData = new[] { 1, 2 }.ToList();

            // Assert the correct sequence is found
            Assert.IsTrue(TestTestCaseData(testCaseData));
        }

        [TestMethod]
        public void TestSequenceAtEnd()
        {
            INumberService numberService = new NumberSequencerService();
            TestCaseData testCaseData = new TestCaseData();

            // Set up a sequence at the start
            testCaseData.InputData = new[] { 9, 9, 1, 2 }.ToList();
            testCaseData.OutputData = new[] { 1, 2 }.ToList();

            // Assert the correct sequence is found
            Assert.IsTrue(TestTestCaseData(testCaseData));
        }

        [TestMethod]
        public void TestLongerSequenceIsReturned()
        {
            INumberService numberService = new NumberSequencerService();
            TestCaseData testCaseData = new TestCaseData();

            // Set up a sequence at the start
            testCaseData.InputData = new[] { 1, 2, 3, 0, 4, 5 }.ToList();
            testCaseData.OutputData = new[] { 1, 2, 3 }.ToList();

            // Assert the correct sequence is found
            Assert.IsTrue(TestTestCaseData(testCaseData));
        }

        [TestMethod]
        public void TestEarlierSequenceIsReturned()
        {
            INumberService numberService = new NumberSequencerService();
            TestCaseData testCaseData = new TestCaseData();

            // Set up a sequence at the start
            testCaseData.InputData = new[] { 4, 5, 6, 1, 2, 3 }.ToList();
            testCaseData.OutputData = new[] { 4, 5, 6 }.ToList();

            // Assert the correct sequence is found
            Assert.IsTrue(TestTestCaseData(testCaseData));
        }

        #endregion


    }
}
