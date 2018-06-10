using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDPrinciples
{
    // just stores a couple of journal entries and ways of
    // working with them
    class Journal
    {
        private readonly List<string> entries = new List<string>();

        private static int count = 0;

        public int AddEntry(string text)
        {
            entries.Add($"{++count}: {text}");
            return count; // memento pattern!
        }

        public void RemoveEntry(int index)
        {
            entries.RemoveAt(index);
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries);
        }

        // breaks single responsibility principle
        public void Save(string filename, bool overwrite = false)
        {
            File.WriteAllText(filename, ToString());
        }

        public void Load(string filename)
        {

        }

        public void Load(Uri uri)
        {

        }

    }

    class Persistence
    {
        public void SaveToFile(string filename, Journal journal, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename))
            {
                File.WriteAllText(filename,journal.ToString());
            }
        }
    }

    //use this to execute
    //var j = new Journal();
    //j.AddEntry("I cried today.");
    //        j.AddEntry("I ate a bug.");
    //        Console.WriteLine(j);
            

    //        var p = new Persistence();
    //var filename = @"c:\temp\journal.txt";
    //p.SaveToFile(filename, j,true);
    //        Process.Start(filename);
}
