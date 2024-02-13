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

    }
}
