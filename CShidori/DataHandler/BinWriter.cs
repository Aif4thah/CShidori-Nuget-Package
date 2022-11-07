using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CShidori.DataHandler
{
    public class BinWriter
    {
        public string FileDump { get; set; }
        public BinWriter( BinLoader bl )
        {
            this.FileDump = bl.FileName + Guid.NewGuid();
            if (!File.Exists(this.FileDump))
                File.WriteAllBytes(this.FileDump, bl.DataBytes);           
        }
    }
}
