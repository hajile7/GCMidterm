﻿using System;
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

    }



}
