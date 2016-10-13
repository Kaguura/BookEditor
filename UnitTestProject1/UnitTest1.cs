using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookEditor.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            ParseBookModel pbm = new ParseBookModel();
            Assert.AreEqual(3, pbm.GetPageCnt());
        }
    }
}
