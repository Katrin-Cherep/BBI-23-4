using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Variant_5
{
    public class Task3
    {
        public struct Rectangle
        {
            public int A { get; private set; }
            public int B { get; private set; }

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

        public Task1(Rectangle[] rectangles)
        {
            _rectangles = rectangles;
        }

        private Rectangle[] _rectangles = new Rectangle[5];
        public Rectangle[] Rectangles { get { return _rectangles; } }

        public override string ToString()
        {
            string r = "";
            foreach (Rectangle rect in _rectangles)
            {
                r += rect.ToString() + '\n';
            }
            return r;
        }

        public void Sorting()
        {
            _rectangles = MergeSort(_rectangles);
        }

        private Rectangle[] MergeSort(Rectangle[] array)
        {
            if (array.Length <= 1)
                return array;

            int mid = array.Length / 2;
            Rectangle[] left = new Rectangle[mid];
            Rectangle[] right = new Rectangle[array.Length - mid];

            Array.Copy(array, 0, left, 0, mid);
            Array.Copy(array, mid, right, 0, array.Length - mid);

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static Rectangle[] Merge(Rectangle[] left, Rectangle[] right)
        {
            int leftIndex = 0, rightIndex = 0, resultIndex = 0;
            Rectangle[] result = new Rectangle[left.Length + right.Length];

            while (leftIndex < left.Length && rightIndex < right.Length)
            {
                if (left[leftIndex].Length() <= right[rightIndex].Length())
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
    }
}
