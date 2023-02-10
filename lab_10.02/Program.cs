using dz_9._02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10._02
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix mass1 = new Matrix();
            Console.WriteLine(mass1);
            for (int i = 0; i < mass1.mass.GetLength(0); i++)
            {
                for (int j = 0; j < mass1.mass.GetLength(1); j++)
                {
                    try
                    {
                        mass1[i, j] = i + j;
                        Console.Write(mass1[i, j] + "\t");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
