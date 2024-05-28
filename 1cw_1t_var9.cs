using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{

    struct Disciple
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

            Disciple[] disciples = new Disciple[5];

            Random random = new Random();

            string[] names = new string[] { "John", "Bill", "Jack", "Sam", "Alex" };

            Array.Sort(names, StringComparer.OrdinalIgnoreCase);

            for (int i = 0; i < disciples.Length; i++)
            {
                disciples[i].Name = names[i];
                disciples[i].Age = random.Next(19, 100);
                disciples[i].Scores = new int[5];

                for (int j = 0; j < disciples[i].Scores.Length; j++)
                {
                    disciples[i].Scores[j] = random.Next(4, 6);
                }
            }

            PrintDisciplesTable(disciples);

            PrintDisciplesDosye(disciples[random.Next(0, 5)]);

            Console.ReadKey();
        }
    }
}