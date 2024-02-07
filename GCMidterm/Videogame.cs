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
        public static Videogame AddPurchase(Videogame v, int quantity)
        {
            v.price *= quantity;
<<<<<<< HEAD
            return v;

        }
        public override string ToString()
=======
            return v; 

        }
       public override string ToString()
>>>>>>> e16aa707966e67ebffecfdb60fdfef03bbeb4275
        {
            string detials = $"{name} {category} {description} {price}";
            return detials;
        }




    }
}