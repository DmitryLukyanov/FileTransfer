using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonSdk
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = MongoDB.Libmongocrypt.Library.Version;
            Console.WriteLine(t);
        }
    }
}
