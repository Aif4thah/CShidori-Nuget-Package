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

        public MutDispatcher(int n, string i)
        {
            if (i != string.Empty)
            {
                this.Output = new List<string>();
                while (n > 0)
                {
                    n -= 1;
                    int rng = RandomNumberGenerator.GetInt32(10);
                    
                    switch (rng)
                    {
                        case 0:
                            this.Output.Add(Mutation.BitFlip(i));
                            break;

                        case 1:
                            this.Output.Add(Mutation.AddRandBc(i));
                            break;

                        case 2:
                            this.Output.Add(Mutation.DelChar(i));
                            break;

                        case 3:
                            this.Output.Add(Mutation.RepThreeBytes(i));
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
        }
    }
}
