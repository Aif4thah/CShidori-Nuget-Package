using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CShidori.Core;

namespace CShidori.DataHandler
{
    public class DataLoader
    {
        //data loaded in BadStrings class and used during mutation 
        public DataLoader(string DataPath, string DataFiles)
        {
            List<string> results = new List<string>();
            List<string> FileList = Directory.GetFiles(DataPath).ToList();
            
            foreach ( string s in DataFiles.Split(","))
            {
                IEnumerable<string> FileNames = from f in FileList where f.EndsWith(s) select f;
                foreach (string FileName in FileNames)
                    foreach (string line in File.ReadAllLines(FileName))
                        BadStrings.Output.Add(line);
            }

        }
    }
}
