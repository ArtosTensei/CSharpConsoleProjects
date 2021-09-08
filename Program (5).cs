using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp9

{
    class Program
    {
        public struct FlatStruct
        {
            public int Rooms;
            public double TotalSquare;
            public double[] SquareRooms;
            public double KitchenSquare;
            public double SquareWC;
            public double SquareBathRoom;
            public int Cost;
            public int FlatNum;

            public FlatStruct(int Rooms, double TotalSquare, double[] SquareRooms, double KitchenSquare, double SquareWC, double SquareBathRoom, int Cost, int FlatNum)
            {
                this.Rooms = Rooms;
                this.TotalSquare = TotalSquare;
                this.SquareRooms = SquareRooms;
                this.KitchenSquare = KitchenSquare;
                this.SquareWC = SquareWC;
                this.SquareBathRoom = SquareBathRoom;
                this.Cost = Cost;
                this.FlatNum = FlatNum;
            }
            public void Print()
            {
                Console.WriteLine();
                Console.WriteLine("Номер квартиры: {0}", this.FlatNum);
                Console.WriteLine("Количество комнат: {0}", this.Rooms);
                Console.WriteLine("Площадь кухни: {0:f2}", this.KitchenSquare);
                Console.WriteLine("Площадь туалета: {0:f2}", this.SquareWC);
                Console.WriteLine("Площадь ванны: {0:f2}", this.SquareBathRoom);
                for (int i = 0; i < this.SquareRooms.Length; i++)
                {
                    Console.WriteLine("Площадь комнаты {0}: {1:f2}", i + 1, this.SquareRooms[i]);
                }
                Console.WriteLine("Цена квартиры: {0:f2}", this.Cost);
                Console.WriteLine("Общая площадь квартиры: {0:f2}", this.TotalSquare);
                Console.WriteLine();
            }
        }
        static void Main()
        {
            try
            {
                //создание листа
                List<FlatStruct> ApartList = new List<FlatStruct>();
                Console.Write("Записать список квартир самому или уже готовый? R - готовый, W - самому. ");
                switch (Console.ReadKey(true).Key)
                {
                    //заполнение значений рандомом
                    case ConsoleKey.R:
                        {
                            Console.WriteLine();
                            Random ran = new Random();
                            int flats = ran.Next(2, 10);
                            for (int i = 0; i < flats; i++)
                            {
                                int FlatNum = i + 1;
                                int RoomsRand = ran.Next(1, 7);
                                double[] SquareRoomsRand = new double[RoomsRand];
                                double KitchenSquareRand = ran.Next(100, 500) * 0.1;
                                double SquareWCRand = ran.Next(100, 200) * 0.1;
                                double SquareBathRoomRand = ran.Next(100, 400) * 0.1;
                                double TotalSquareRand = KitchenSquareRand + SquareWCRand + SquareBathRoomRand;
                                int CostRand = ran.Next(100000, 5000000);
                                for (int j = 0; j < SquareRoomsRand.Length; j++)
                                {
                                    SquareRoomsRand[j] = ran.Next(100, 600) * 0.1;
                                    TotalSquareRand += SquareRoomsRand[j];
                                }
                                //объект структуры
                                FlatStruct FlatsObj = new FlatStruct(RoomsRand, TotalSquareRand, SquareRoomsRand, KitchenSquareRand, SquareWCRand, SquareBathRoomRand, CostRand, FlatNum);
                                ApartList.Add(FlatsObj);
                            }
                            //вывод списка
                            foreach (FlatStruct house in ApartList)
                                house.Print();
                        }
                        break;
                    //заполнение вручную
                    case ConsoleKey.W:
                        {
                            Console.WriteLine();
                            Console.Write("Введите количество квартир: ");
                            int Flats = Convert.ToInt32(Console.ReadLine());
                            for (int i = 0; i < Flats; i++)
                            {
                                int FlatNum = i + 1;
                                Console.WriteLine();
                                Console.WriteLine("Квартира №{0}", FlatNum);
                                Console.Write("Введите количество комнат в квартире: ");
                                int Rooms = Convert.ToInt32(Console.ReadLine());
                                double[] SquareRooms = new double[Rooms];
                                Console.Write("Введите площадь кухни: ");
                                double KitchenSquare = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Введите площадь туалета: ");
                                double SquareWC = Convert.ToDouble(Console.ReadLine());
                                Console.Write("Введите площадь ванны: ");
                                double SquareBathRoom = Convert.ToDouble(Console.ReadLine());
                                double TotalSquare = KitchenSquare + SquareWC + SquareBathRoom;
                                for (int j = 0; j < SquareRooms.Length; j++)
                                {
                                    Console.Write("Введите площадь комнаты {0}: ", j + 1);
                                    SquareRooms[j] = Convert.ToDouble(Console.ReadLine());
                                    TotalSquare += SquareRooms[j];
                                }
                                Console.Write("Введите цену квартиры: ");
                                int Cost = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                //объект структуры
                                FlatStruct FlatsObj = new FlatStruct(Rooms, TotalSquare, SquareRooms, KitchenSquare, SquareWC, SquareBathRoom, Cost, FlatNum);
                                ApartList.Add(FlatsObj);
                            }
                        }
                        break;
                }
                //сортировка по цене
                BubbleSort(ApartList);
                Console.WriteLine("Сортировка по цене");
                Console.WriteLine();
                foreach (FlatStruct house in ApartList)
                    house.Print();
                Console.WriteLine("Введите количество комнат для вычисления медианы: ");
                int RoomsFunc = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Введите площадь для вычисления медианы");
                double TotalSquareFunc = Convert.ToDouble(Console.ReadLine());
                find(RoomsFunc, TotalSquareFunc, ApartList);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        public static void find(int RoomsFunc, double TotalSquareFunc, List<FlatStruct> Flat)
        {
            List<FlatStruct> home = new List<FlatStruct>();
            int med;
            foreach (FlatStruct apart in Flat)
            {
                if (RoomsFunc == apart.Rooms && apart.TotalSquare > TotalSquareFunc)
                {
                    home.Add(apart);
                }
            }
            if (home.Count % 2 == 0)
            {
                med = (home[(home.Count / 2) - 1].Cost + home[home.Count / 2].Cost) / 2;
            }
            else
            {
                med = (home[home.Count / 2].Cost);
            }
            Console.WriteLine("Медиана: {0}", med);
        }
        public static void BubbleSort(List<FlatStruct> Flat)
        {
            for (int i = 0; i < Flat.Count - 1; i++)
            {
                for (int j = i + 1; j < Flat.Count; j++)
                {
                    if (Flat[i].Cost > Flat[j].Cost)
                    {
                        FlatStruct temp = Flat[j];
                        Flat[j] = Flat[i];
                        Flat[i] = temp;
                    }
                }
            }
        }
    }
}
