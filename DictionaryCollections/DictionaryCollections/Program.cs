using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace DictionaryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            ht["0"] = "zero";
            ht["1"] = "one";
            ht["2"] = "two";
            ht["3"] = "three";
            ht["4"] = "four";
            ht["5"] = "five";
            ht["6"] = "six";
            ht["7"] = "seven";
            ht["8"] = "eight";
            ht["9"] = "nine";

            string str = "67469246";

            foreach (char c in str)
            {
                string digit = c.ToString();
                if (ht.ContainsKey(digit))
                {
                    Console.WriteLine(ht[digit]);
                }
            }
        }
    }
}
