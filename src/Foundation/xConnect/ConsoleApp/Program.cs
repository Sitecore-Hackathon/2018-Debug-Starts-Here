using Helixbase.Foundation.xConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating OrderApiModel: ");
            string json = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(OrderApiModel.Model);
            Console.Write(json);
            System.IO.File.WriteAllText($".\\{OrderApiModel.Model.FullName}.json", json);
            Console.ReadKey();
        }
    }
}
