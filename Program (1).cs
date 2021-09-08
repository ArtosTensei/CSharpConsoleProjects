using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Введите изначальное предложение: ");
                string text = Console.ReadLine();
                Find(text);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        public static void Find(string text)
        {
            char[] charsText = text.ToCharArray();
            char[] charsLowReg = text.ToLower().ToCharArray();
            string c = new string("");
            for (int i = 0; i < charsText.Length; i++)
            {
                if (text.Count(s => s == charsLowReg[i]) == 1 && charsLowReg[i] != ' ' && charsLowReg[i] != '.' && charsLowReg[i] != ',' && charsLowReg[i] != '!' && charsLowReg[i] != '?')
                {
                    c = charsLowReg[i].ToString();
                    i = charsText.Length;
                }
                else if(text.Count(s => s == charsText[i]) == 1)
                {
                    c = charsLowReg[i].ToString();
                }
            }
            for (int i = 0; i < charsText.Length; i++)
            {
                if (c.Equals(charsText[i].ToString(), StringComparison.OrdinalIgnoreCase) && charsLowReg[i] != ' ' && charsLowReg[i] != '.' && charsLowReg[i] != ',' && charsLowReg[i] != '!' && charsLowReg[i] != '?')
                {
                    c = charsText[i].ToString();
                }
            }
            Console.WriteLine(c);
        }
    }
}
