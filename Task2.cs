using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task2
    {
        public abstract class Rectangle
        {
            public int A { get; protected set; }
            public int B { get; protected set; }

            public Rectangle(int a, int b) { A = a; B = b; }

            public int Area()
            {
                return A * B;
            }

            public int Length()
            {
                return A * 2 + B * 2;
            }

            public int Compare(Rectangle other)
            {
                if (other.Area() > this.Area())
                    return -1;
                else if (other.Area() < this.Area())
                    return 1;
                return 0;
            }

            public override string ToString()
            {
                return $"a={A}, b={B}, p={this.Length()}, s={this.Area()}";
            }

        }


        public abstract class Embrasure : Rectangle
        {

            public string Name { get; set; }

            public int Width { get { return A; } set { A = value; } }
            public int Height { get { return B; } set { B = value; } }
            public int C { get; set; }



            public Embrasure(int a, int b, int thick) : base(a, b)
            {
                C = thick;
            }


            public virtual int Cost()
            {
                return Width * Height * 10;
            }

            public override string ToString()
            {
                return $"Type= Embrasure, p={this.Length()}, s={this.Area()}, price={this.Cost()}";
            }
        }


        public class Window : Embrasure
        {

            public int Layers { get; private set; }

            public Window(int a, int b, int thick, int l_count) : base(a, b, thick)
            {
                Layers = l_count;
            }

            public override int Cost()
            {
                return base.Cost() + (int)(Layers / 0.3);
            }
        }

        public class Door : Embrasure
        {
            public string Material { get; private set; }

            public Door(int a, int b, int thick, string m) : base(a, b, thick)
            {
                Material = m;
            }

            public override int Cost()
            {
                double mult = 1;
                if (Material == "пластик")
                    mult = 1.25;
                else if (Material == "металл")
                    mult = 1.33;
                else if (Material == "дерево")
                    mult = 1.5;
                return (int)(base.Cost() * mult);
            }
        }


        private Embrasure[] _embrasures = new Embrasure[5];
        public Embrasure[] Embrasures { get { return _embrasures; } }

        public Task2(Embrasure[] embrasures)
        {
            _embrasures = embrasures;
        }

        public void Sorting()
        {
            _embrasures = MergeSort(_embrasures);
        }

        private Embrasure[] MergeSort(Embrasure[] array)
        {
            if (array.Length <= 1)
                return array;

            int mid = array.Length / 2;
            Embrasure[] left = new Embrasure[mid];
            Embrasure[] right = new Embrasure[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static Embrasure[] Merge(Embrasure[] left, Embrasure[] right)
        {
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            Embrasure[] result = new Embrasure[left.Length + right.Length];

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].Cost() <= right[rightIndex].Cost())
                {
                    result[resultIndex++] = left[leftIndex++];
                }
                else
                {
                    result[resultIndex++] = right[rightIndex++];
                }
            }

            while (leftIndex < left.Length)
            {
                result[resultIndex++] = left[leftIndex++];
            }

            while (rightIndex < right.Length)
            {
                result[resultIndex++] = right[rightIndex++];
            }

            return result;
        }

        public override string ToString()
        {
            string r = "";
            foreach (Embrasure rect in Embrasures)
            {
                r += rect.ToString() + '\n';
            }
            Console.WriteLine(r);
            return r;
        }
    }
}
