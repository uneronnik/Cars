using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dz24_06_21.Interfaces;
using dz24_06_21.Classes.Cars;

namespace dz24_06_21
{
    class Program
    {
        static void Main(string[] args)
        {
            ICar Haval = new HavalH9();
            ICar FordMustang = new FordMustang();

            Haval.Show();
            Console.WriteLine();
            FordMustang.Show();
            Console.ReadKey();
        }
    }
}
