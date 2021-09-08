using System;



namespace ConsoleApp9
{
    class Program
    {
        static void Main()
        {
            try
            {
                int[,] arr = { { 2, 6, 7, 9, 9, 14 }, { 18, 20, 26, 26, 40, 40 }, { 44, 47, 50, 51, 55, 62 } };
                int num = 40;
                Searcher(arr, num);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void Searcher(int[,] arr, int num)
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == num)
                    {
                        Console.WriteLine("Индексы искомого значения: [" + i + "," + j + "]");
                        break;
                    }
                }
            }
        }
    }
}
