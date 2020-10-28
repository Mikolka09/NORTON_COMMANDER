using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NortonCommander
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.UTF8;


            Performance pref = new Performance();
            pref.launchPanelCommander();

            Console.ReadLine();

        }
    }
}
