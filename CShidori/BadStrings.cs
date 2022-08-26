using System;
using System.Linq;
using System.Web;
using System.Text;
using System.Collections.Generic;
using CShidori.DataHandler;

namespace CShidori.Core
{
    public static class BadStrings
    {
        
        public static List<string> Output {get;set;} = new List<string> { // default list, when DataLoader is not called
            string.Empty,
            System.Environment.NewLine,
            "*",
            "+",
            "-",
            "/",
            "\\",
            "=",
            "&",
            "%",
            "$",
            ";",
            "[",
            "]",
            "(",
            ")",
            "|",
            "?",
            "\"",
            "'",
            "`",
            "@",
            "#",
            "!",
            ".",
            ":",
            "<",
            ">",
            "«",
            "»",
            "}",
            "{",
            "0",
            "-1",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\n",
            "\r",
            "\r\n",
            "undefined",
            "undef",
            "null",
            "NULL",
            "(null)",
            "nil",
            "NIL",
            "true",
            "false",
            "True",
            "False",
            "TRUE",
            "FALSE",
            "None",
            "NaN",
            "{{7*7}}",
            "${7*7}",
            "<%= 7*7 %>",
            "${{7*7}}",
            "#{7*7}",
            String.Concat(Enumerable.Repeat("9",4097))         
        }; 

        

    }
}
