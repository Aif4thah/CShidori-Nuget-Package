using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CShidori.Core
{
    public class MutDispatcher
    {
        public List<string>? Output { set; get; }
        public List<byte[]>? BytesOutput { set; get; }

        public MutDispatcher(int n = 1, string i = "", byte[] b = null )
        {
            if ("" != i)
            {
                this.Output = new List<string>();
                while(0 < n)
                {
                    n -= 1;
                    int rng = RandomNumberGenerator.GetInt32(10);
                    
                    switch(rng)
                    {
                        case 0:
                            this.Output.Add(
                                Encoding.UTF8.GetString(Mutation.BitFlip(Encoding.UTF8.GetBytes(i).ToArray())));
                            break;

                        case 1:
                            this.Output.Add(Mutation.AddRandBc(i));
                            break;

                        case 2:
                            this.Output.Add(Mutation.DelChar(i));
                            break;

                        case 3:
                            this.Output.Add(
                               Encoding.UTF8.GetString(Mutation.RepBytes(Encoding.UTF8.GetBytes(i).ToArray())));
                            break;

                        case 4:
                            this.Output.Add(Mutation.RepLine(i));
                            break;

                        case 5:
                            this.Output.Add(Mutation.RepeatStr(i));
                            break;

                        default:
                            this.Output.Add(Mutation.RepRandBc(i));
                            break;
                    }

                }
            }


            if (null != b)
            {
                this.BytesOutput = new List<byte[]>();
                while(0 < n)
                {
                    n -= 1;
                    int rng = RandomNumberGenerator.GetInt32(1);

                    switch(rng)
                    {
                        case 0:
                            this.BytesOutput.Add(Mutation.BitFlip(b.ToArray()));
                            break;

                        default:
                            this.BytesOutput.Add(Mutation.RepBytes(b.ToArray()));
                            break;

                    } 
                }
            }
        }
    }
}
