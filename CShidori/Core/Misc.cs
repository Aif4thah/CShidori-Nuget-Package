using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using CShidori.DataHandler;
using System.Security.Cryptography;

namespace CShidori.Core
{
    public static class Misc
    {
        public static string GetIp()
        {
            string localIP = string.Empty;
            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    localIP = endPoint.Address.ToString();
                }
            }
            catch{ localIP = "127.0.0.1";}

            return localIP;
        }

        public static string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIFKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }


        public static string GetSha256Hash(string f)
        {
            using (var hashAlgorithm = SHA512.Create())
            {
                var byteValue = File.ReadAllBytes(f);
                var byteHash = hashAlgorithm.ComputeHash(byteValue);
                return Convert.ToBase64String(byteHash);
            }
        }

    }
}
