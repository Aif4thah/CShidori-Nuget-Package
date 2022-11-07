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
    public class MutationTests
    {

        
        [TestMethod()]
        public void RepRandBcTest()
        {
            string p = Misc.RandomString(10);
            string result = Mutation.RepRandBc(p);
            System.Diagnostics.Trace.WriteLine(p);
            Assert.IsTrue(result.Length >= p.Length && result != p);
        }

        [TestMethod()]
        public void AddRandBcTest()
        {
            string p = Misc.RandomString(10);
            string result = Mutation.AddRandBc(p);
            System.Diagnostics.Trace.WriteLine(p);
            Assert.IsTrue(result.Length > p.Length);
        }

        [TestMethod()]
        public void RepLineTest()
        {
            string p = @"
            line1
            line2
            line3
            ";
            string result = Mutation.RepLine(p);
            System.Diagnostics.Trace.WriteLine(p);
            Assert.IsTrue(result != String.Empty && result != p);
        }

        [TestMethod()]
        public void DelCharTest()
        {
            string p = Misc.RandomString(10);
            string result = Mutation.DelChar(p);
            System.Diagnostics.Trace.WriteLine(p);
            Assert.IsTrue(result != String.Empty && result.Length < p.Length);
        }

        [TestMethod()]
        public void BitFlipTest()
        {
            byte[] b = Encoding.UTF8.GetBytes("aaaaa");
            byte[] result = Mutation.BitFlip(b.ToArray());
            System.Diagnostics.Trace.WriteLine(Encoding.UTF8.GetString(b));
            System.Diagnostics.Trace.WriteLine(Encoding.UTF8.GetString(result));
            Assert.IsTrue(result != b && result.Length == b.Length);
        }


        [TestMethod()]
        public void RepBytesTest()
        {
            byte[] b = Encoding.UTF8.GetBytes("aaaaa");
            System.Diagnostics.Trace.WriteLine(Encoding.UTF8.GetString(b));
            byte[] result = Mutation.RepBytes(b.ToArray());
            System.Diagnostics.Trace.WriteLine(Encoding.UTF8.GetString(result));
            Assert.IsTrue(result != b);
        }

        [TestMethod()]
        public void RepeatStrTest()
        {
            string p = Misc.RandomString(10);
            string result = Mutation.RepeatStr(p);
            System.Diagnostics.Trace.WriteLine(p);
            Assert.IsTrue(result.Length >= p.Length);            
        }
    }

}