using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Threading.Tasks;
using CShidori.DataHandler;

namespace CShidori.Core
{
    public static class EncodeStrings
    {
        public static void EncodeBadStrings()        
        {
            foreach (string input in BadStrings.Output.ToList())
            {
                BadStrings.Output.Add(Uri.EscapeDataString(input));
                BadStrings.Output.Add(HttpUtility.UrlEncode(input));
                BadStrings.Output.Add(HttpUtility.UrlEncodeUnicode(input));
                BadStrings.Output.Add(HttpUtility.HtmlEncode(input));
                BadStrings.Output.Add(Convert.ToBase64String(Encoding.UTF8.GetBytes(input)));

                //Escape quotes
                BadStrings.Output.Add(EscapeQuotes(input));

                //hexEscape
                BadStrings.Output.Add(HexEscapeString(input));

                //html ascii:
                BadStrings.Output.Add(AsciiEncode(input));
                BadStrings.Output.Add(AsciiHexEncode(input));
            }
            BadStrings.Output.Distinct().ToList();

        }



        private static string EscapeQuotes(string str)
        {
            return str.Replace("\\", "\\\\").Replace("\"", "\\\"").Replace("'", "\\'");
        }


        private static string HexEscapeString(string str)
        {
            string hexstr = string.Empty;
            foreach (char c in str)
            {
                try { hexstr += Uri.HexEscape(c); }
                catch { hexstr += c; }               
            }
            return hexstr;
        }

        private static string AsciiEncode(string str)
        {
            string htmlASCIIEncoded = string.Empty; ;
            foreach (char c in str)
            {
                try
                {
                    int val = Convert.ToInt32(c);
                    if (val < 128) //if ASCCI not extended
                    {
                        htmlASCIIEncoded += "&#" + val.ToString() + ";";
                    }
                }
                catch { htmlASCIIEncoded += c; }
            }
            return htmlASCIIEncoded;
        }


        private static string AsciiHexEncode(string str)
        {
            string htmlASCIIHexEncoded = string.Empty; ;
            foreach (char c in str)
            {
                try
                {
                    int val = Convert.ToInt32(c);
                    if (val < 128) //if ASCCI not extended
                    {
                        htmlASCIIHexEncoded += "&#x" + val.ToString("X") + ";";
                    }
                }
                catch { htmlASCIIHexEncoded += c; }
            }
            return htmlASCIIHexEncoded;


        }
    }
}
