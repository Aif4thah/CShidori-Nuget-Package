using Microsoft.VisualStudio.TestTools.UnitTesting;
using CShidori.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CShidori.DataHandler;

namespace CShidori.Core.Tests
{
    [TestClass()]
    public class MutDispatcherTests
    {
        [TestMethod()]
        public void MutDispatcherTest()
        {
            MutDispatcher result;
            int o = 10;
            List<string> list = new List<string>() 
            {
                Misc.RandomString(1), Misc.RandomString(10), Misc.RandomString(100),
            };

            foreach(string s in list)
            {
                result = new MutDispatcher(o, s);
                System.Diagnostics.Trace.WriteLine(s + " -> " + result.Output.FirstOrDefault());
                Assert.IsTrue(result.Output.Count == o && result.Output.FirstOrDefault() != s);
            }

            



        }

        [TestMethod()]
        public void MutationFuzz()
        {
            MutDispatcher result = new MutDispatcher(1024, Misc.RandomString(10));
            foreach (string r in result.Output)
            {
                System.Diagnostics.Trace.WriteLine(r);
                new MutDispatcher(i: r);
            }



        }

    }
}