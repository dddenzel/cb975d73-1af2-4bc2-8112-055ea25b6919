﻿using CodeTest.Services;
using CodeTest.Testing.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace CodeTest.Testing
{
    [TestClass]
    public class TestExpectedData : BaseTest
    {
        [TestMethod]
        public void TestCase1()
        {
            TestTestCaseData(GetTestCaseData("TestCase1.json"));
        }

        [TestMethod]
        public void TestCase2()
        {
            TestTestCaseData(GetTestCaseData("TestCase2.json"));
        }

        [TestMethod]
        public void TestCase3()
        {
            TestTestCaseData(GetTestCaseData("TestCase3.json"));
        }

        [TestMethod]
        public void TestCase4()
        {
            TestTestCaseData(GetTestCaseData("TestCase4.json"));
        }

        [TestMethod]
        public void TestCase5()
        {
            TestTestCaseData(GetTestCaseData("TestCase5.json"));
        }

        [TestMethod]
        public void TestCase6()
        {
            TestTestCaseData(GetTestCaseData("TestCase6.json"));
        }

        [TestMethod]
        public void TestCase7()
        {
            TestTestCaseData(GetTestCaseData("TestCase7.json"));
        }

        [TestMethod]
        public void TestCase8()
        {
            TestTestCaseData(GetTestCaseData("TestCase8.json"));
        }

        [TestMethod]
        public void TestCase9()
        {
            TestTestCaseData(GetTestCaseData("TestCase9.json"));
        }
        
    }
}