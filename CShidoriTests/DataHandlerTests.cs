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
    public class DataHandlerTests
    {
        [TestMethod()]
        public void BinLoaderAndWriterTest()
        {
            byte[] b = Encoding.UTF8.GetBytes("aaaaa");
            string f = "test";

            if (File.Exists(f))
            {
                File.Delete(f);
                System.Diagnostics.Trace.WriteLine(f + "removed");
            }

            File.WriteAllBytes(f, b);
            BinLoader bl = new BinLoader(f);

            BinWriter bw = new BinWriter(bl);
            string hashRef = Misc.GetSha256Hash(f);
            string hashCmp = Misc.GetSha256Hash(bw.FileDump);

            System.Diagnostics.Trace.WriteLine(hashRef + " vs " + hashCmp);
            Assert.IsTrue(hashRef == hashCmp);
            
            File.Delete(f);
            File.Delete(bl.FileName);
            File.Delete(bw.FileDump);


        }
    }
}