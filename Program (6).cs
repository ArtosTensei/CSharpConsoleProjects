using System;



namespace ConsoleApp9
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

            public rec(double x1, double y1, double x2, double y2, double x3, double y3, double x4, double y4)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
                this.x3 = x3;
                this.y3 = y3;
                this.x4 = x4;
                this.y4 = y4;
            }
            public void Randrec()
            {
                Random ran = new Random();
                this.x1 = ran.Next(-1000, 999) * 0.1;
                this.x2 = ran.Next((int)x1+1, 1000) * 0.1;
                this.x3 = this.x2;
                this.x4 = this.x1;
                this.y1 = ran.Next(-1000, 1000) * 0.1;
                this.y2 = this.y1;
                this.y3 = ran.Next(-999, (int)y1-1) * 0.1;
                this.y4 = this.y3;
            }
            public void Print()
            {
                Console.WriteLine("Координата точки x1: {0:F2} y1: {1:F2}", this.x1, this.y1);
                Console.WriteLine("Координата точки x2: {0:F2} y2: {1:F2}", this.x2, this.y2);
                Console.WriteLine("Координата точки x3: {0:F2} y3: {1:F2}", this.x3, this.y3); 
                Console.WriteLine("Координата точки x4: {0:F2} y4: {1:F2}", this.x4, this.y4);
                Console.WriteLine();
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
                    //рандом и вывод массива
                    arrec[i].Randrec();
                    arrec[i].Print();
                }
                //поиск и вывод координат искомого прямоугольника
                rec Total = new rec(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
                Total = find(arrec);
                Console.WriteLine();
                Total.Print();
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static rec find(rec[] rec)
        {
            rec temprec = new rec(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0);
            temprec = rec[0];
            for (int i = 0; i < rec.Length; i++)
            {
                if (temprec.x1 > rec[i].x1)
                {
                    temprec.x1 = rec[i].x1;
                }
                if (temprec.x2 < rec[i].x2)
                {
                    temprec.x2 = rec[i].x2;
                }
                if (temprec.x3 < rec[i].x3)
                {
                    temprec.x3 = rec[i].x3;
                }
                if (temprec.x4 > rec[i].x4)
                {
                    temprec.x4 = rec[i].x4;
                }
                if (temprec.y1 < rec[i].y1)
                {
                    temprec.y1 = rec[i].y1;
                }
                if (temprec.y2 < rec[i].y2)
                {
                    temprec.y2 = rec[i].y2;
                }
                if (temprec.y3 > rec[i].y3)
                {
                    temprec.y3 = rec[i].y3;
                }
                if (temprec.y4 > rec[i].y4)
                {
                    temprec.y4 = rec[i].y4;
                }
            }
            return temprec;
        }
    }
}
