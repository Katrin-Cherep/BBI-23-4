using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1cw_2t_vor
{
    namespace task2
    {

        class Disciple
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public int[] Scores { get; set; }
            public double AverageScore
            {
                get
                {
                    float avr = 0;
                    foreach (var s in Scores)
                        avr += s;
                    avr /= 5;
                    return avr;
                }
            }
            public bool Status
            {
                get
                {
                    float avr = 0;
                    foreach (var s in Scores)
                        avr += s;
                    avr /= 5;
                    return avr >= 4.5;
                }
            }

            public Disciple(int[] scores)
            {
                Name = "";
                Age = 0;
                Scores = scores;
            }

            public override string ToString()
            {
                return $"{Name}\tAge: {Age}\tScores: {string.Join("\t", Scores)}\tAverage: {AverageScore:F2}\t" + (Status ? "Red" : "");
            }

        }


        class Pupil : Disciple
        {

            public int Class { get; set; }

            public string Specialization { get; set; }

            public Pupil(int[] scores) : base(scores)
            {
                Class = 0;
                Specialization = "";
            }
        }

        class Student : Disciple
        {
            private static int _obj_counter = 0;

            public int StudID { get; private set; }

            public int Group { get; set; }

            public bool IsDebtor
            {
                get
                {
                    foreach (var s in Scores)
                    {
                        if (s <= 2)
                            return true;
                    }
                    return false;
                }
            }


            public Student(int[] scores) : base(scores)
            {
                _obj_counter++;
                StudID = _obj_counter;

            }
        }




        class Program
        {
            static void PrintDisciplesTable(Disciple[] d)
            {
                Console.WriteLine("=================");
                Console.WriteLine("Name\t|\tMath\t|\tPhysics\t| Chemistry\t| Biology\t| History\t| Status\t|");
                foreach (var disciple in d)
                {
                    Console.Write(disciple.Name + "\t|\t");
                    foreach (var s in disciple.Scores)
                    {
                        Console.Write(s.ToString() + "\t|\t");
                    }
                    Console.WriteLine((IsStudentStatus(disciple) ? "Red" : " ") + "\t|\t");
                }
                Console.WriteLine("=================");
            }

            static bool IsStudentStatus(Disciple d)
            {
                return d.Status;
            }

            static void PrintDisciplesDosye(Disciple d)
            {
                Console.WriteLine(d.ToString());
            }

            static void Main(string[] args)
            {

                Random rnd = new Random();

                int[,] school_t = new int[3, 5];
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        school_t[i, j] = rnd.Next(1, 6);
                    }
                }

                int[,] stud_t = new int[2, 5];
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        school_t[i, j] = rnd.Next(1, 6);
                    }
                }


                Disciple[] all = new Disciple[5];



                for (int i = 0; i < 3; i++)
                    all[i] = new Pupil(Enumerable.Range(0, school_t.GetLength(1)).Select(x => school_t[i, x]).ToArray());

                for (int i = 0; i < 2; i++)
                    all[i + 3] = new Pupil(Enumerable.Range(0, stud_t.GetLength(1)).Select(x => stud_t[i, x]).ToArray());

                string[] names = { "John", "Bill", "Jack", "Sam", "Alex" };
                for (int i = 0; i < all.Length; i++)
                {
                    all[i].Name = names[i];
                }


                PrintDisciplesTable(all);

                Console.ReadKey();
            }
        }
    }
}
    

