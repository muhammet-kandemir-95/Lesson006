using System;

namespace Lesson006
{
    public class Program_MaxNumber
    {
        public static void Main_MaxNumber(string[] args)
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

            int maxNumber = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > maxNumber)
                {
                    maxNumber = numbers[i];
                }
            }
            
            Console.WriteLine("Max Number is " + maxNumber + ".");
        }
    }
}