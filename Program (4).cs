using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCFindSimilar
{
    class Program
    {
        public struct SHuman
        {
            public string Surname;          // фамилия
            public string Firstname;        // имя
            public string Patronymic;       // отчество
            public int Year;                // год рождения
            public SHuman(string surname, string firstname, string patronymic, int year)
            {
                this.Surname = surname;
                this.Firstname = firstname;
                this.Patronymic = patronymic;
                this.Year = year;
            }
        }
        static void Main(string[] args)
        {
            try
            {
                SHuman[] Group = {new SHuman("Пушкин", "Александр", "Сергеевич", 1799),
                            new SHuman("Ломоносов", "Михаил", "Васильевич", 1711),
                            new SHuman("Тютчев", "Фёдор", "Иванович", 1803),
                            new SHuman("Суворов", "Александр", "Васильевич", 1729),
                            new SHuman("Менделеев", "Дмитрий", "Иванович", 1834),
                            new SHuman("Ахматова", "Анна", "Андреевна", 1889),
                            new SHuman("Володин", "Александр", "Моисеевич", 1919),
                            new SHuman("Мухина", "Вера", "Игнатьевна", 1889),
                            new SHuman("Верещагин", "Петр", "Петрович", 1834),
                            new SHuman("Саунин", "Антон", "Владиславович", 2000)};

                List<SHuman> GroupList = new List<SHuman>();
                GroupList = ListWork(Group);
                List<List<SHuman>> AllGroups = new List<List<SHuman>>();
                while (GroupList.Count > 0)
                {
                    List<SHuman> TempList = new List<SHuman>();
                    FirstnameCheck(ref GroupList, ref TempList);
                    SurnameCheck(ref GroupList, ref TempList);
                    PatronymicCheck(ref GroupList, ref TempList);
                    YearCheck(ref GroupList, ref TempList);
                    if (TempList.Count > 0)
                    {
                        AllGroups.Add(TempList);
                    }
                    else
                    {
                        AllGroups.Add(GroupList);
                        break;
                    }
                }
                Print(AllGroups);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }
        public static void Delete(ref List<SHuman> Humans, ref List<SHuman> FirstGroup)
        {
            foreach (SHuman mate in FirstGroup)
            {
                Humans.Remove(mate);
            }
        }
        public static List<SHuman> FirstnameCheck(ref List<SHuman> Humans, ref List<SHuman> FirstGroup)
        {
            String temp = new string("");
            if (FirstGroup.Count == 0)
            {
                for (int i = 0; i < Humans.Count - 1; i++)
                {
                    for (int j = i + 1; j < Humans.Count; j++)
                    {
                        if (Humans[i].Firstname == Humans[j].Firstname)
                        {
                            if (temp == "")
                            {
                                temp = Humans[i].Firstname;
                            }
                            if (!FirstGroup.Contains(Humans[i]) && temp == Humans[i].Firstname)
                            {
                                FirstGroup.Add(Humans[i]);
                            }
                            if (!FirstGroup.Contains(Humans[j]) && temp == Humans[j].Firstname)
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < FirstGroup.Count; i++)
                {
                    for (int j = 0; j < Humans.Count; j++)
                    {
                        if (FirstGroup[i].Firstname == Humans[j].Firstname)
                        {
                            if (!FirstGroup.Contains(Humans[j]))
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            Delete(ref Humans, ref FirstGroup);
            return FirstGroup;
        }
        public static List<SHuman> SurnameCheck(ref List<SHuman> Humans, ref List<SHuman> FirstGroup)
        {
            String temp = new string("");
            if (FirstGroup.Count == 0)
            {
                for (int i = 0; i < Humans.Count - 1; i++)
                {
                    for (int j = i + 1; j < Humans.Count; j++)
                    {
                        if (Humans[i].Surname == Humans[j].Surname)
                        {
                            if (temp == "")
                            {
                                temp = Humans[i].Surname;
                            }
                            if (!FirstGroup.Contains(Humans[i]) && temp == Humans[i].Surname)
                            {
                                FirstGroup.Add(Humans[i]);
                            }
                            if (!FirstGroup.Contains(Humans[j]) && temp == Humans[j].Surname)
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < FirstGroup.Count; i++)
                {
                    for (int j = 0; j < Humans.Count; j++)
                    {
                        if (FirstGroup[i].Surname == Humans[j].Surname)
                        {
                            if (!FirstGroup.Contains(Humans[j]))
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            Delete(ref Humans, ref FirstGroup);
            return FirstGroup;
        }

        public static List<SHuman> PatronymicCheck(ref List<SHuman> Humans, ref List<SHuman> FirstGroup)
        {
            String temp = new string("");
            if (FirstGroup.Count == 0)
            {
                for (int i = 0; i < Humans.Count - 1; i++)
                {
                    for (int j = i + 1; j < Humans.Count; j++)
                    {

                        if (Humans[i].Patronymic == Humans[j].Patronymic)
                        {
                            if (temp == "")
                            {
                                temp = Humans[i].Patronymic;
                            }
                            if (!FirstGroup.Contains(Humans[i]) && temp == Humans[i].Patronymic)
                            {
                                FirstGroup.Add(Humans[i]);
                            }
                            if (!FirstGroup.Contains(Humans[j]) && temp == Humans[j].Patronymic)
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < FirstGroup.Count; i++)
                {
                    for (int j = 0; j < Humans.Count; j++)
                    {
                        if (FirstGroup[i].Patronymic == Humans[j].Patronymic)
                        {
                            if (!FirstGroup.Contains(Humans[j]))
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            Delete(ref Humans, ref FirstGroup);
            return FirstGroup;
        }
        public static List<SHuman> YearCheck(ref List<SHuman> Humans, ref List<SHuman> FirstGroup)
        {
            int temp = 0;
            if (FirstGroup.Count == 0)
            {
                for (int i = 0; i < Humans.Count - 1; i++)
                {
                    for (int j = i + 1; j < Humans.Count; j++)
                    {

                        if (Humans[i].Year == Humans[j].Year)
                        {
                            if (temp == 0)
                            {
                                temp = Humans[i].Year;
                            }
                            if (!FirstGroup.Contains(Humans[i]) && temp == Humans[i].Year)
                            {
                                FirstGroup.Add(Humans[i]);
                            }
                            if (!FirstGroup.Contains(Humans[j]) && temp == Humans[j].Year)
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < FirstGroup.Count; i++)
                {
                    for (int j = 0; j < Humans.Count; j++)
                    {
                        if (FirstGroup[i].Year == Humans[j].Year)
                        {
                            if (!FirstGroup.Contains(Humans[j]))
                            {
                                FirstGroup.Add(Humans[j]);
                            }
                        }
                    }
                }
            }
            Delete(ref Humans, ref FirstGroup);
            return FirstGroup;
        }
        public static void Print(List<SHuman> FirstGroup)
        {
            foreach (SHuman mate in FirstGroup)
            {
                Console.WriteLine(mate.Surname + " " + mate.Firstname + " " + mate.Patronymic + " " + mate.Year);
            }
        }
        public static void Print(List<List<SHuman>> AllGroups)
        {
            int c = 0;
            foreach (List<SHuman> Group in AllGroups)
            {
                c++;
                Console.WriteLine("Группа №{0}", c);
                foreach (SHuman mate in Group)
                {
                    Console.WriteLine(mate.Surname + " " + mate.Firstname + " " + mate.Patronymic + " " + mate.Year);
                }

            }
        }
        public static List<SHuman> ListWork(SHuman[] Group)
        {
            List<SHuman> HumansList = new List<SHuman>();
            foreach (SHuman Human in Group)
            {
                HumansList.Add(Human);
            }
            return HumansList;
        }
    }
}