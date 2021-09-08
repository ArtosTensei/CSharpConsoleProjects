using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            int teach, stud;
            try
            {
                Console.Write("Введите количество преподавателей: ");
                teach = Convert.ToInt32(Console.ReadLine());
                while (teach > 1000 || teach <= 0)
                {
                    Console.Write("Вы ввели неправильное значение, введите новое: ");
                    teach = Convert.ToInt32(Console.ReadLine());
                }
                Console.Write("Введите количество студентов: ");
                stud = Convert.ToInt32(Console.ReadLine());
                while (stud > 1000 || stud <= 0)
                {
                    Console.Write("Вы ввели неправильное значение, введите новое: ");
                    stud = Convert.ToInt32(Console.ReadLine());
                }
                double[,] arrMarks = new double[teach, stud];
                Random ran = new Random();
                //заполнение массива случайными значениями от 0.0 до 5.0
                for (int i = 0; i < arrMarks.GetLength(0); i++)
                {
                    for (int j = 0; j < arrMarks.GetLength(1); j++)
                    {
                        arrMarks[i, j] = ran.Next(0, 50) * 0.1;
                        //Вывод массива
                        Console.Write("{0:F1}\t", arrMarks[i, j]);
                    }
                    Console.WriteLine();
                }
                teacher(arrMarks);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void teacher(double[,] arrMarks)
        {
            int index = 0, nums = arrMarks.GetLength(1) - 2;
            double sum = 0, max, min;
            double[] t = new double[arrMarks.GetLength(0)];
            for (int i = 0; i < arrMarks.GetLength(0); i++)
            {
                max = -1;
                min = 6;
                sum = 0;
                for (int j = 0; j < arrMarks.GetLength(1); j++)
                {
                    if (arrMarks[i, j] > max)
                    {
                        max = arrMarks[i, j];
                    }
                    if (arrMarks[i, j] < min)
                    {
                        min = arrMarks[i, j];
                    }
                    sum += arrMarks[i, j];
                }
                sum -= max;
                sum -= min;
                t[i] = sum / nums;
            }
            max = -1;
            for (int i = 0; i < t.GetLength(0); i++)
            {
                if (t[i] > max)
                {
                    max = t[i];
                    index = i;
                }
            }
            Console.WriteLine("Индекс лучшего преподаватель: " + index);
            Console.WriteLine("Среднее максимальное значение: {0:F2}", max);
        }
    }
}
