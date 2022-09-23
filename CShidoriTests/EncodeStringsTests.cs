using Microsoft.VisualStudio.TestTools.UnitTesting;
using CShidori.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CShidori.DataHandler;
using CShidori.Generator;

namespace CShidori.Core.Tests
{
    [TestClass()]
    public class EncodeStringsTests
    {
        [TestMethod()]
        public void EncodeStringTest()
        {
            int DefaultList = BadStrings.Output.Count;
            EncodeStrings.EncodeBadStrings();
            Assert.IsTrue(DefaultList < BadStrings.Output.Count);

        }

    }
}