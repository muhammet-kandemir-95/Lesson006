using System;

namespace Lesson006
{
    public class Program_SortAscending
    {
        public static void Main_SortAscending(string[] args)
        {
            Console.Write("Please enter numbers count: ");
            int numberCount = Convert.ToInt32(Console.ReadLine());

            int[] numbers = new int[numberCount];
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.Write("Please enter " + (i + 1) + ". number: ");
                numbers[i] = Convert.ToInt32(Console.ReadLine());
            }

            // numbers were filled!
            int[] sortedNumbers = new int[numbers.Length];
            bool[] addedNumbersIndexes = new bool[numbers.Length];

            for (int i = 0; i < sortedNumbers.Length; i++)
            {
                int min = 0;
                int minIndex = 0;
                for (int j = 0; j < addedNumbersIndexes.Length; j++) // Find the first false
                {
                    if (addedNumbersIndexes[j] == false)
                    {
                        min = numbers[j];
                        minIndex = j;
                        break;
                    }
                }

                for (int j = 0; j < numbers.Length; j++)
                {
                    if(numbers[j] < min && addedNumbersIndexes[j] == false)
                    {
                        min = numbers[j];
                        minIndex = j;
                    }
                }

                addedNumbersIndexes[minIndex] = true;
                sortedNumbers[i] = min;
            }

            for (int i = 0; i < sortedNumbers.Length; i++)
            {
                Console.WriteLine((i + 1) + ". number is " + sortedNumbers[i] + ".");
            }
        }
    }
}