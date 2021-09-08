using System;
using System.Collections.Generic;

namespace PCFindSimilar
{

    class Rutishausers
    {

        public struct Rutishauser
        {
            public char Charr;
            public int Weight;
            public Rutishauser(char Charr, int Weight)
            {
                this.Charr = Charr;
                this.Weight = Weight;
            }
            public void Print()
            {
                Console.WriteLine();
                Console.WriteLine("Символ: " + this.Charr);
                Console.WriteLine("Вес: " + this.Weight);
            }
        }

        public void count(string Chars)
        {
            List<Rutishauser> space = weightcount(Chars);
        bigmistake:
            int max = -1;
            int c1 = 0;
            int c2 = 0;
            int c3 = 0;
            int i = 0;
            double a = 0;
            foreach (Rutishauser count in space)
            {
                if (count.Weight > max)
                {
                    max = count.Weight;
                    c1 = i;
                }
                if (count.Weight == max)
                {
                    c2 = i;
                }
                i++;
            }
            c3 = c2 - 1;
            switch (space[c3].Charr)
            {
                case '*':
                    a = Char.GetNumericValue(space[c1].Charr) * Char.GetNumericValue(space[c2].Charr);
                    break;
                case '-':
                    a = Char.GetNumericValue(space[c1].Charr) - Char.GetNumericValue(space[c2].Charr);
                    break;
                case '+':
                    a = Char.GetNumericValue(space[c1].Charr) + Char.GetNumericValue(space[c2].Charr);
                    break;
                case '/':
                    a = Char.GetNumericValue(space[c1].Charr) / Char.GetNumericValue(space[c2].Charr);
                    break;
            }
            int b = Convert.ToInt32(a);
            string b1 = Convert.ToString(b);
            space.RemoveAt(c2 + 1);
            space.RemoveAt(c2);
            space.RemoveAt(c3);
            space.RemoveAt(c1);
            space.RemoveAt(c1 - 1);
            space.Insert(c1 - 1, new Rutishauser(Convert.ToChar(b1), max - 1));  
            c1 = -1;
            c2 = -1;
            c3 = -1;
            if (space.Count > 2)
            {
                goto bigmistake;
            }
            Print(space);
        }

        public void Print(List<Rutishauser> list)
        {
            foreach (Rutishauser write in list)
            {
                Console.WriteLine("Ответ: " + write.Charr);
            }
        }

        public List<Rutishauser> weightcount(string Chars)
        {
            char[] chars = Chars.ToCharArray();
            List<int> weights = new List<int>();
            int c = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                switch (chars[i])
                {
                    case '(':
                        c++;
                        weights.Add(c);
                        break;
                    case ')':
                        c--;
                        weights.Add(c);
                        break;
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                        c--;
                        weights.Add(c);
                        break;
                    default:
                        c++;
                        weights.Add(c);
                        break;
                }
            }

            List<Rutishauser> Listt = new List<Rutishauser>();
            for (int i = 0; i < chars.Length; i++)
            {
                Rutishauser work = new Rutishauser(chars[i], weights[i]);
                Listt.Add(work);
            }
            return Listt;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Проверяться алгоритм будет на выражении: (1+(2*2))");
                String Chars = "(1+(2*2))";
                Rutishausers test = new Rutishausers();
                test.count(Chars);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
    }
}