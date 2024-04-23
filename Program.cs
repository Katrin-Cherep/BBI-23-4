using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] sarr = s.Split(' ', '.', '\t', ';', '\n');

            List<string> list = new List<string>();

            for (int i = 0; i < sarr.Length; i++)
            {
                if (sarr[i].Length > 1)
                {
                    if (sarr[i].Length == sarr[i].ToLower().Distinct().Count())
                    {
                        list.Add(sarr[i]);
                    }
                }
            }

            foreach (string _s in list)
            {
                Console.WriteLine(_s);
            }

            Console.ReadKey();
        }
    }

}
