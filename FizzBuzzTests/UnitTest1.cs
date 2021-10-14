using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FizBuzz.Models;

namespace FizzBuzzTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FizzBuzzValidFizz()
        {
            int testNum = 6;
            String expected = "Fizz";

            String res = SeedData.getFizzBuzz(testNum);

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void FizzBuzzValidBuzz()
        {
            int testNum = 25;
            String expected = "Buzz";

            String res = SeedData.getFizzBuzz(testNum);

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void FizzBuzzValidFizzBuzz()
        {
            int testNum = 15;
            String expected = "FizzBuzz";

            String res = SeedData.getFizzBuzz(testNum);

            Assert.AreEqual(res, expected);
        }

        [TestMethod]
        public void FizzBuzzValidNum()
        {
            int testNum = 38;
            String expected = "38";

            String res = SeedData.getFizzBuzz(testNum);

            Assert.AreEqual(res, expected);
        }

    }
}
