using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ConsoleApp1
{


    public class Program
    {
        static void Main(string[] args)
        {
            Controller m_engine = new Controller(@"C:\testFoleder");
            m_engine.start();
            Console.ReadLine();
        }
    }
}
