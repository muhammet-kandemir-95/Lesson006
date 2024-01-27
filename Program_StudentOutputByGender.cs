using System;

namespace Lesson006
{
    public class Program_StudentOutputByGender
    {
        public static void Main_StudentOutputByGender(string[] args)
        {
            Console.Write("Please enter student count: ");
            int studentCount = Convert.ToInt32(Console.ReadLine());

            string[] names = new string[studentCount];
            string[] surnames = new string[studentCount];
            bool[] genders = new bool[studentCount]; // True = Male, False = Female

            for (int i = 0; i < studentCount; i++)
            {
                Console.Write("Please enter " + (i + 1) + ". student name: ");
                names[i] = Console.ReadLine();
                
                Console.Write("Please enter " + (i + 1) + ". student surname: ");
                surnames[i] = Console.ReadLine();
                
                Console.Write("Please enter " + (i + 1) + ". student gender(M/F): ");
                if (Console.ReadLine() == "M")
                {
                    genders[i] = true;
                }
            }

            // Students were filled!

            string maleNames = "";
            string femaleNames = "";
            for (int i = 0; i < studentCount; i++)
            {
                if (genders[i]) // He is
                {
                    if (maleNames != "")
                    {
                        maleNames += ", ";
                    }

                    maleNames += names[i] + " " + surnames[i];
                }
                else // She
                {
                    if (femaleNames != "")
                    {
                        femaleNames += ", ";
                    }

                    femaleNames += names[i] + " " + surnames[i];
                }
            }

            Console.WriteLine("Male Students Fullnames: " + maleNames);
            Console.WriteLine("Female Students Fullnames: " + femaleNames);
        }
    }
}