using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace GCMidterm
{
    internal class Videogame
    {
        //properties
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }

        //constructor 
        public Videogame(string _name, string _category, string _description, decimal _price)
        {
            name = _name;
            category = _category;
            description = _description;
            price = _price;
        }
        //Purchase Method
        public static decimal AddPurchase(Videogame v, int quantity)
        {
            return v.price * quantity;
        }
        //Formatted list method
        public override string ToString()

        {
            return string.Format("{0, -20} {1, -15} {2, -40} {3, 10:C}", name, category, description, price); //:C will convert price to currency
        }

        public static decimal TaxRate(decimal x, decimal y)
        {
            return x * y; 
        }

        public static string GrandtotalCalc(decimal x, decimal y)
        {
            decimal taxamount = Videogame.TaxRate(y, x);
            return
            $"Your subtotal is: {x:C}\nSales Tax: {Math.Round(Videogame.TaxRate(y,x),2):C}\n" +
            $"Your grand total is: {Math.Round(taxamount + x, 2):C}";


           
            
        }
    }



}
