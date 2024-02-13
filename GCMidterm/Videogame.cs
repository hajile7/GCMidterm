using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GCMidterm
{
    internal class Videogame
    {
        //properties
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }

        //constructor 
        public Videogame(string _name, string _category, string _description, decimal _price, int _quantity)
        {
            name = _name;
            category = _category;
            description = _description;
            price = _price;
            quantity = _quantity;
        }

        //Purchase Method
        public static decimal AddPurchase(Videogame v, int quantity)
        {
            return v.price * quantity;
        }

        //Formatted list method
        public override string ToString()

        {
            return string.Format("{0, -20} {1, -15} {2, -40} {3, 10:C} {4, 15}", name, category, description, price, quantity); //:C will convert price to currency
        }

        //Tax Method
        public static decimal TaxRate(decimal x, decimal y)
        {
            return x * y;
        }

        //Subtotal method before payment
        public static string GrandTotalPrint(decimal x, decimal y)
        {
            decimal taxamount = Videogame.TaxRate(y, x);
            return "====================================\n" + string.Format("{0, -13}{1, 23}\n{2, -12}{3, 23}\n{4, -13}{5, 23}",
            "Subtotal:", $"{x:C}", "Tax:", $"{TaxRate(y, x):C}", "Total:", $"{Math.Round(taxamount + x, 2):C}") + "\n====================================";
        }

        //get grand total method
        public static decimal GrandTotalAmount(decimal x, decimal y)
        {
            return x + (x * y);
        }


        //Cash method
        public static decimal GetChange(decimal cash, decimal total)
        {
            return cash - total;
        }

        //Final Receipt method
        public static void FinalReceipt(List<Videogame> list, decimal x, decimal y)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("|             RECEIPT              |");
            Console.WriteLine("====================================");
            Console.WriteLine(string.Format("{0, -19} {1, -8}{2,8:C}", "Title", "Amt.", "Price"));
            foreach (Videogame v in list.DistinctBy(g => g.name).ToList()) //returns list of unique games purchased
            {
                int count = 0;
                decimal gameprice = v.price;
                foreach (Videogame v2 in list.Where(x => x.name == v.name).ToList()) //second list that keeps track of how many copies of each unique game were purchased
                {
                    count++;
                }
                gameprice *= count; //updates the unique game's price without changing reference value                    
                Console.WriteLine(string.Format("{0, -19} ({1}){2,13:C}", v.name, count, gameprice));
            }
            Console.WriteLine(GrandTotalPrint(x, y));
        }
    }

}
