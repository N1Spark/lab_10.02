using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz_9._02
{
    public class Matrix
    {
        public static int rows;
        public static int cols;
        public int[,] mass = new int[rows, cols];
        private int min { get; set; } = 0;
        private int max { get; set; } = 0;
        public Matrix()
        {
            Random random = new Random();
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                    mass[i, j] = random.Next(1, 20);
            for (int i = 0; i < rows; i++)
                for (int j = 0; j < cols; j++)
                {
                    if (min > mass[i, j])
                        min = mass[i, j];
                    if (max < mass[i, j])
                        max = mass[i, j];
                }
        }

        static Matrix()
        {
            Console.Write("Введите кол-во строк: ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите кол-во столбцов: ");
            cols = Convert.ToInt32(Console.ReadLine());
        }

        public void Print()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                    Console.Write(mass[i, j] + "\t");
                Console.WriteLine();
            }
            Console.WriteLine($"Min: {min};\nMax: {max}");
        }

        public override string ToString()
        {
            Print();
            return "";
        }

        public static Matrix operator +(Matrix a, int b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                    a.mass[i, j] += b;
            return a;
        }
        public static Matrix operator -(Matrix a, int b)
        {
            int buf = b * -1;
            return a + buf;
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                    a.mass[i, j] += b.mass[i, j];
            return a;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                    a.mass[i, j] -= b.mass[i, j];
            return a;
        }
        public static Matrix operator *(Matrix a, int b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                    a.mass[i, j] *= b;
            return a;
        }
        public static Matrix operator *(Matrix a, Matrix b)
        {
            Matrix buf = new Matrix();
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                    for (int k = 0; k < a.mass.GetLength(0); k++)
                        buf.mass[i, j] += a.mass[i, k] * b.mass[k, j];
            return buf;
        }
        public static bool operator ==(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                {
                    if (a.mass[i, j] != b.mass[i, j])
                        return false;
                }
            return true;
        }
        public static bool operator !=(Matrix a, Matrix b)
        {
            for (int i = 0; i < a.mass.GetLength(0); i++)
                for (int j = 0; j < a.mass.GetLength(1); j++)
                {
                    if (a.mass[i, j] == b.mass[i, j])
                        return false;
                }
            return true;
        }
        public int this[int r, int c]
        {
            get
            {
                if(r<0||r>=mass.GetLength(0))
                {
                    throw new Exception("Некоректный индекс!" + r);
                }
                else if(c<0||c>=mass.GetLength(1))
                {
                    throw new Exception("Некоректный индекс!" + c);
                }
                else
                {
                    return mass[r, c];
                }
            }
            set
            {
                if (r < 0 || r >= mass.GetLength(0))
                {
                    throw new Exception("Некоректный индекс!" + r);
                }
                else if (c < 0 || c >= mass.GetLength(1))
                {
                    throw new Exception("Некоректный индекс!" + c);
                }
                else
                {
                    mass[r, c] = value ;
                }
            }
        }
    }
}