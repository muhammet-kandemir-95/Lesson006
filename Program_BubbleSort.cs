using System;

namespace Lesson006
{
    public class Program_BubbleSort
    {
        public static void Main_BubbleSort(string[] args)
        {
            int[] a = { 3, 0, 2, 5, -1, 4, 1 }; // Initializing an array with values
            int t; // Temporary variable for swapping

            Console.WriteLine("Original array :");
            for (int i = 0; i < a.Length; i++)
            {
                int aa = a[i];
                Console.Write(aa + " "); // Printing each element of the array
            }

            for (int p = 0; p < a.Length - 1; p++) // Outer loop for passes
            {
                for (int i = 0; i < a.Length - 1; i++) // Inner loop for comparison and swapping
                {
                    if (a[i] > a[i + 1]) // Checking if the current element is greater than the next element
                    {
                        t = a[i + 1]; // Swapping elements if they are in the wrong order
                        a[i + 1] = a[i];
                        a[i] = t;
                    }
                }
            }

            Console.WriteLine("\n" + "Sorted array :");
            for (int i = 0; i < a.Length; i++)
            {
                int aa = a[i];
                Console.Write(aa + " "); // Printing each element of the array
            }

            Console.Write("\n"); // Adding a new line at the end
        }
    }
}