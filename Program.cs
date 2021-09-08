using System;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            int[,] ar1 = new int[5, 5];
            Random ran = new Random();
            //заполнение массива случайными значениями от 1 до 10
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar1.GetLength(1); j++)
                {
                    ar1[i, j] = ran.Next(1, 10);
                    //вывод массива с форматированием
                    Console.Write("{0}\t", ar1[i, j]);
                }
                Console.WriteLine();
            }
            Arrayy(ar1);
            Console.ReadKey();
        }

        static void Arrayy(int[,] ar1)
        {
            float a = 0, b = 0, c;
            //проходим по массиву
            for (int i = 0; i < ar1.GetLength(0); i++)
            {
                for (int j = 0; j < ar1.GetLength(1); j++)
                {
                    //считаем среднее с проверкой
                    if (i % 2 == 0 && j % 2 == 0)   
                    {
                        a += ar1[i, j];
                        b++;
                    }
                }
            }
            c = a / b;
            Console.WriteLine("Среднее арифметическое элементов с четными индексами: " + c);
        }
    }
}
