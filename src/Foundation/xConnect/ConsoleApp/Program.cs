using Helixbase.Foundation.xConnect.Models.Facets;
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
            Console.WriteLine("Creating GoogleApiModel: ");
            string json = Sitecore.XConnect.Serialization.XdbModelWriter.Serialize(GoogleApiModel.Model);
            Console.Write(json);
            System.IO.File.WriteAllText($".\\{GoogleApiModel.Model.FullName}.json", json);
            Console.ReadKey();
        }
    }
}
