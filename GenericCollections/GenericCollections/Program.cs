using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, String> dict = new Dictionary<int, String>();

            dict[36] = "Hungary";
            dict[666] = "PonyLand";
            dict[0] = "Nowhere";
            dict[13] = "United Kingdom";

            Console.WriteLine("The 666 code is for: {0}", dict[666]);

            foreach (KeyValuePair<int, String> item in dict)
            {
                int code = item.Key;
                string country = item.Value;
                Console.WriteLine("Code {0} = {1}", code, country);
            }
            Console.Read();
        }
    }
}
