using System;
using System.IO;

namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            int width;
            try
            {
                Console.Write("Введите ширину калейдоскопа (половину стороны)\nВводимое число должно быть от 3 до 20: ");
                width = Convert.ToInt32(Console.ReadLine());
                //цикл проверки

                while (width < 3 || width > 20)
                {
                    Console.WriteLine("Введено неверное число. Попробуйте снова");
                    Console.WriteLine("Введите ширину калейдоскопа (половину стороны): ");
                    width = Convert.ToInt32(Console.ReadLine());
                }
                print(width);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void print(int width)
        {
            //получение массива цветов
            ConsoleColor[] colors = (ConsoleColor[])ConsoleColor.GetValues(typeof(ConsoleColor));
            int[,] prints = new int[width + 1, width + 1];
            int numbers, Rand;
            Random run = new Random();
            numbers = Convert.ToInt32(colors.Length);
            //отрисовка четверти
            for (int i = 1; i <= width; i++)
            {
                for (int j = 1; j <= width; j++)
                {
                    Rand = run.Next(numbers);
                    prints[i, j] = Rand;
                    Console.BackgroundColor = colors[prints[i, j]];
                    Console.Write(" ");
                }
                //отрисовка второй четверти
                for (int j = width; j >= 1; j--)
                {
                    Console.BackgroundColor = colors[prints[i, j]];
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
            //отрисковка оставшихся четвертей
            for (int i = width; i >= 1; i--)
            {
                for (int j = 1; j <= width; j++)
                {
                    Console.BackgroundColor = colors[prints[i, j]];
                    Console.Write(" ");
                }
                for (int j = width; j >= 1; j--)
                {
                    Console.BackgroundColor = colors[prints[i, j]];
                    Console.Write(" ");
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }

        }
    }
}
