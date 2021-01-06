using System;

namespace FileTransfer_with_local_package
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = MongoDB.Libmongocrypt.Library.Version;
        }
    }
}
