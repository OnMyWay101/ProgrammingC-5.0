using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Ch3_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            Console.WriteLine("Folder path:" + path);
            string[] files = Directory.GetFiles(path);
            var comparer = new LengthCompare();
            Array.Sort(files, comparer);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }
            Console.ReadLine();
        }

        private class LengthCompare : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                int diff = x.Length - y.Length;
                return diff == 0 ? x.CompareTo(y) : diff;
            }
        }
    }
}
