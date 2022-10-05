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

            int o = 10;
            string p = Misc.RandomString(10);
            MutDispatcher result = new MutDispatcher(o, p);
            Assert.IsTrue(result.Output.Count == o);

        }

        [TestMethod()]
        public void MutationFuzz()
        {
            MutDispatcher result = new MutDispatcher(1024, Misc.RandomString(10));
            result.Output.ForEach(x => new MutDispatcher(1024, x));

        }

    }
}