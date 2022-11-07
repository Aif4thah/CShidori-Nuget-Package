﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using CShidori.DataHandler;
using CShidori.Core;

namespace CShidori.Core
{
    public static class Mutation
    {
         
        public static string RepRandBc(string p)
        {         
            int randvalue = RandomNumberGenerator.GetInt32(p.Length);
            int randbc = RandomNumberGenerator.GetInt32(BadStrings.Output.Count);  
            
            StringBuilder sb = new StringBuilder(p);
            sb.Remove(randvalue, 1);     
            
            return sb.ToString().Insert(randvalue, BadStrings.Output[randbc]);
        }


        public static string AddRandBc(string p)
        {
            int randvalue = RandomNumberGenerator.GetInt32(p.Length);
            int randbc = RandomNumberGenerator.GetInt32(BadStrings.Output.Count);

            return p.Insert(randvalue, BadStrings.Output[randbc]);
        }

        public static string RepLine(string p)
        {
            string[] lines = p.Split('\n');
            int randvalue = RandomNumberGenerator.GetInt32(lines.Length);
            int randbc = RandomNumberGenerator.GetInt32(BadStrings.Output.Count);
            lines[randvalue] = BadStrings.Output[randbc];

            return String.Join('\n', lines);
        }


        public static string DelChar(string p)
        {
            int randvalue = RandomNumberGenerator.GetInt32(p.Length);
            StringBuilder sb = new StringBuilder(p);
            
            return sb.Remove(randvalue, 1).ToString();
        }

        public static byte[] BitFlip(byte[] bytes)
        {
            byte[] bitW = { 0x01, 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };

            int randvalue = RandomNumberGenerator.GetInt32(bytes.Length);
            int randbit = RandomNumberGenerator.GetInt32(bitW.Length);

            try { bytes[randvalue] += bitW[randbit]; }
            catch { bytes[randvalue] -= bitW[randbit]; }

            return bytes;
        }


        public static byte[] RepBytes(byte[] bytes)
        {
            int byteLength = RandomNumberGenerator.GetInt32(4);
            if (bytes.Length < byteLength)
            {
                bytes.Concat(Encoding.UTF8.GetBytes(Misc.RandomString(byteLength-1)));
            }
            byte[] ByteRange = new byte[byteLength];

            int randvalue = RandomNumberGenerator.GetInt32(bytes.Length - 2);
            RandomNumberGenerator.Create().GetBytes(ByteRange);

            for(int i = 0; i < byteLength; i++)
                bytes[randvalue + i] = ByteRange[i];

            return bytes;
        }


        public static string RepeatStr(string p)
        {

            StringBuilder sb = new StringBuilder(p);
            int startIndex = RandomNumberGenerator.GetInt32(sb.Length);
            
            return p + sb.ToString(startIndex, sb.Length - startIndex);
           
        }


    }
}