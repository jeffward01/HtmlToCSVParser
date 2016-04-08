using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
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

            
            var path = String.Format("{0}csvFiles\\", AppDomain.CurrentDomain.BaseDirectory);
            var filePath = System.IO.Path.Combine(path, "LicenseRequest.csv");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            File.WriteAllText(filePath, output);
            
            



            System.Console.WriteLine(output);
            System.Console.WriteLine(filePath);
            System.Console.ReadLine();

        }
    }
}
