using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShidori.DataHandler
{
    public class BinLoader
    {
        public byte[] DataBytes { get; set; }
        public string FileName { get; set; }

        public BinLoader(string FileName)
        {
            this.FileName = FileName;
            this.DataBytes = File.ReadAllBytes(FileName);
        }
    }
}
