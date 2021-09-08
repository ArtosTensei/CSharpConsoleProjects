using System;
using System.Linq;

namespace PCFindSimilar
{
    class Program
    {
        static void Main()
        {
            try
            {
                Console.Write("Введите изначальное слово: ");
                string text = Console.ReadLine();
                Console.Write("Введите сколько слов вы будете проверять: ");
                int c = Convert.ToInt32(Console.ReadLine());
                string[] arrWords = new string[c];
                for (int i = 0; i < c; i++)
                {
                    Console.Write("Слово №{0}: ", (i + 1));
                    arrWords[i] = Console.ReadLine();
                    Console.WriteLine("Составляется ли слово " + arrWords[i] + " из слова " + text + "? Ответ: " + Compare(text, arrWords[i]));
                }
                Console.WriteLine("\nВсе слова были проверены.");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static bool Compare(string text, string word)
        {
            char[] charsWord = word.ToCharArray();
            int c = 0;
            for (int i = 0; i < charsWord.Length; i++)
            {
                switch (text.Count(s => s == charsWord[i]))
                {
                    case 0:
                        break;
                    case 1:
                        {
                            if (word.Count(s => s == charsWord[i]) == 2)
                            {
                                break;
                            }
                            if (word.Count(s => s == charsWord[i]) == 1)
                            {
                                c++;
                            }
                            break;
                        }
                    case 2:
                        {
                            if (word.Count(s => s == charsWord[i]) == 2)
                            {
                                c++;
                            }
                            if (word.Count(s => s == charsWord[i]) == 1)
                            {
                                c++;
                            }
                            break;
                        }
                }
            }
            if (c == charsWord.Length && charsWord.Length > 0)
            {
                return true;
            }
            else
                return false;
        }
    }
}