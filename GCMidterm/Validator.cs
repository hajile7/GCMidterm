using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Validtor
{
    public class Validator
    {
        //Logan's method for getting a valid string based on input list
       public static string GetValidString(List<string> list)
        {
               string result = Console.ReadLine().Trim().ToLower();
             
            while (!list.Contains(result))
            {
                Console.WriteLine("Invalid, please try again");
                result = Console.ReadLine().Trim().ToLower();
            }
           return result;
        }

        //Getting int within number range
        public static int GetInputInt(int x, int y, string s)
        {
            int result = -1;
            while (!int.TryParse(Console.ReadLine(), out result) || (result < x || result > y)) 
            {
                Console.WriteLine($"{s}");
            }
            return result;
        }

        //Getting decimal in reference to num
        public static decimal GetInputDecimal(decimal x, string s)
        {
            decimal result = -1;
            while (!decimal.TryParse(Console.ReadLine(), out result) || result <= x)
            {
                Console.WriteLine($"{s}");
            }
            return result;
        }
        public static int GetInputInt()
        {
            int result = -1;
            while (!int.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Invalid input.");
            }
            return result;
        }

        public static double GetInputDouble()
        {
            double result = -1;
            while (double.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid input.");
            }
            return result;
        }

        public static float GetInputFloat()
        {
            float result = -1;
            while (float.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid input.");
            }
            return result;
        }
        public static decimal GetInputDecimal()
        {
            decimal result = -1;
            while (decimal.TryParse(Console.ReadLine(), out result) == false)
            {
                Console.WriteLine("Invalid input.");
            }
            return result;
        }
        public static int GetPositiveInputInt()
        {
            int result = -1;
            while (int.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static double GetPositiveInputDouble()
        {
            double result = -1;
            while (double.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static float GetPositiveInputFloat()
        {
            float result = -1;
            while (float.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }
        public static decimal GetPositiveInputDecimal()
        {
            decimal result = -1;
            while (decimal.TryParse(Console.ReadLine(), out result) == false || result <= 0)
            {
                Console.WriteLine("Invalid input. Try again with a positive number.");
            }
            return result;
        }

        public static bool GetContinue()
        {
            bool result = false;
            while (true)
            {
                Console.WriteLine("Would you like to run again? y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if(choice == "y")
                {
                    result = true;
                    break;
                }
                else if(choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
            return result;
        }

        public static bool GetContinue(string message)
        {
            bool result = false;
            while (true)
            {
                Console.WriteLine($"{message} y/n");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == "y")
                {
                    result = true;
                    break;
                }
                else if (choice == "n")
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
            return result;
        }

        public static bool GetContinue(string message, string y, string n)
        {
            bool result = false;
            while (true)
            {
                Console.WriteLine($"{message} {y}/{n}");
                string choice = Console.ReadLine().Trim().ToLower();
                if (choice == y.ToLower())
                {
                    result = true;
                    break;
                }
                else if (choice == n.ToLower())
                {
                    result = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again");
                }
            }
            return result;
        }


        public static bool numberCheck(int x, int y)
        {
            if(x > y)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
