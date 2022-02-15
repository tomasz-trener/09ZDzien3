using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04PolaczenieZBaza
{
    class Program
    {
        static void Main(string[] args)
        {
            PolaczenieZBaza pzb = new PolaczenieZBaza();

            string[][] wynik= pzb.WykonajZapytanieSQL("select * from skocznie");

            foreach (var w in wynik)
                Console.WriteLine(string.Join(" ", w));

            Console.ReadKey();
        }
    }
}
