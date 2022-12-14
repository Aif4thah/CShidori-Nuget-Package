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
            BadStrings.Output.Add("aaaa");
            int DefaultListCount = BadStrings.Output.Count;
            System.Diagnostics.Trace.WriteLine(DefaultListCount.ToString());
            EncodeStrings.EncodeBadStrings();
            System.Diagnostics.Trace.WriteLine(BadStrings.Output.Count.ToString());
            Assert.IsTrue(DefaultListCount < BadStrings.Output.Count);

        }

        [TestMethod()]
        public void EncodeStringFuzz()
        {
            MutDispatcher result = new MutDispatcher(4096, Misc.RandomString(20));

            BadStrings.Output.Clear();
            Assert.IsTrue(BadStrings.Output.Count == 0 && result.Output.Count > 0);

            foreach ( string Mutation in result.Output)
            {
                BadStrings.Output.Add(Mutation);
                System.Diagnostics.Trace.WriteLine(Mutation);
                EncodeStrings.EncodeBadStrings(); //  <-- test de la fonction
                BadStrings.Output.Clear();
                
            }
            BadStrings.Output.Add("aaaa");
            Assert.IsTrue(BadStrings.Output.Count == 1);
        }

    }
}