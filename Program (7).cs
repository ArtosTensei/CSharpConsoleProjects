using System;



namespace ConsoleApp1
{
    class Program
    {
        public struct rec
        {
            public double x1;
            public double y1;
            public double x2;
            public double y2;
            public double x3;
            public double y3;
            public double x4;
            public double y4;
            public int pix;
            public ConsoleColor col;
            public bool colin;
            public double x12;
            public double x13;
            public double perim;

            public rec(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4, int pix, ConsoleColor col, bool colin, double x12, double x13, double perim)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
                this.col = col;
                this.colin = colin;
                this.pix = pix;
                this.x12 = x12;
                this.x13 = x13;
                this.perim = perim;
            }
            public void Randrec()
            {
                Random ran = new Random();
                this.x1 = ran.Next(-1000, 999) * 0.1;
                this.x2 = ran.Next((int)this.x1 + 1, 1000) * 0.1;
                this.x3 = this.x2;
                this.x4 = this.x1;
                this.y1 = ran.Next(-1000, 1000) * 0.1;
                this.y2 = this.y1;
                this.y3 = ran.Next(-999, (int)this.y1 - 1) * 0.1;
                this.y4 = this.y3;
                this.pix = ran.Next(1, 1000);
                double trueProbability = 0.2;
                this.colin = ran.NextDouble() < trueProbability;
                this.col = GetRandomConsoleColor();
            }
            public void Print(int i)
            {
                i++;
                Console.WriteLine("Прямоугольник номер: " + i);
                Console.WriteLine("Координата точки x1: {0:F2} y1: {1:F2}", this.x1, this.y1);
                Console.WriteLine("Координата точки x2: {0:F2} y2: {1:F2}", this.x2, this.y2);
                Console.WriteLine("Координата точки x3: {0:F2} y3: {1:F2}", this.x3, this.y3);
                Console.WriteLine("Координата точки x4: {0:F2} y4: {1:F2}", this.x4, this.y4);
                Console.WriteLine("Ширина линии: " + pix);
                Console.WriteLine("Цвет прямоугольника: " + col);
                Console.WriteLine("Заливка внутри: " + colin);
                Console.WriteLine("Периметр: " + perim);
                Console.WriteLine();
            }
            //рандом цвета
            private static Random _random = new Random();
            private static ConsoleColor GetRandomConsoleColor()
            {
                var consoleColors = Enum.GetValues(typeof(ConsoleColor));
                return (ConsoleColor)consoleColors.GetValue(_random.Next(consoleColors.Length));
            }
            //вычисление стороны
            public void side()
            {
                this.x12 = Math.Sqrt((this.x2 - this.x1) * (this.x2 - this.x1) + (this.y2 - this.y1) * (this.y2 - this.y1));
                this.x13 = Math.Sqrt((this.x3 - this.x1) * (this.x3 - this.y1) + (this.y3 - this.y1) * (this.y3 - this.y1));
            }
            //вычисление периметра
            public void perimm()
            {
                if (x12 == x13)
                {
                    Console.WriteLine("Это не прямоугольник");
                }
                else
                    this.perim = (x12 + x13) * 2;
            }
        }
        static void Main()
        {
            try
            {
                //число прямоугольников менять здесь ^-^
                rec[] arrec = new rec[5];
                for (int i = 0; i < arrec.Length; i++)
                {
                    //рандом, вычисление стороны, периметра и вывод массива
                    arrec[i].Randrec();
                    arrec[i].side();
                    arrec[i].perimm();
                    arrec[i].Print(i);
                }
                //поиск и вывод координат искомого прямоугольника
                find(arrec);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static void find(rec[] arrec)
        {
            double min_perim = 300.0;
            //счетчик
            int c = 0;
            for (int i = 0; i < arrec.Length; i++)
            {
                if (arrec[i].perim > min_perim)
                {
                    c++;
                }
            }
            Console.WriteLine("Число прямоугольников: " + c);
        }
    }
}
