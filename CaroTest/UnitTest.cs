using NUnit.Framework;
using System;

namespace CaroTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Console.Write("AAA");
        }

        [Test]
        public void Test1()
        {
            Assert.Fail();
        }

        [Test]
        public void TTT()
        {
            Assert.Pass();
        }
    }
}