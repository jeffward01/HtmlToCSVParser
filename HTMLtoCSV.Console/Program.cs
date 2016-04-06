using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLtoCSV.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("TEST");
            var output = HtmlToCSV.GetCSVAttachement();
            System.Console.WriteLine(output);
            System.Console.ReadLine();

        }
    }
}
