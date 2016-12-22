using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LogHelper;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {

            // LogHelper.LogHelper _log = new LogHelper.LogHelper("test");
            LogHelper.LogHelper _log = new LogHelper.LogHelper("g:\\temp2\\one.txt",true);
            _log.WriteLine("asdf");
            Console.Read();
        }
    }
}
