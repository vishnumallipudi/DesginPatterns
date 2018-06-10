using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntry("I cried today.");
            j.AddEntry("I ate a bug.");
            Console.WriteLine(j);
            

            var p = new Persistence();
            var filename = @"c:\temp\journal.txt";
            p.SaveToFile(filename, j,true);
            Process.Start(filename);

            Console.ReadLine();
        }
    }
}
