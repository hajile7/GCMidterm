//Welcome
using GCMidterm;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Validtor;

string filepath = "../../../games.txt"; //Name text file here so we can delete it at the end of program to restock
bool runProg = true;
List<Videogame> videogames = new List<Videogame>();
while (runProg)
{
    Console.WriteLine("Welcome to the videogame store!\n");

    //create text file for games 
    if (File.Exists(filepath) == false)
    {
        StreamWriter writer = new StreamWriter(filepath);
        writer.WriteLine("Celeste|Platformer|Challenging, Pixel Art, Indie|19.99|25");
        writer.WriteLine("Hollow Knight|Metrovania|Challenging, Action, Indie|19.99|25");
        writer.WriteLine("Apex Legends|FPS|Multiplayer, Competitive, F2P| 0.00|25");
        writer.WriteLine("Pokemon Crystal|RPG|Immersive, Pixel Art, Adventure|  75.00|2");
        writer.WriteLine("Factorio|Factory Builder|Immersive, Problem-Solving, 2D|35.00|25");
        writer.WriteLine("Super Meat Boy|Platformer|Challenging, Pixel Art, Indie|14.99|25");
        writer.WriteLine("Elden Ring|Souls-like|Challenging, Open-World, Immersive|60.00|25");
        writer.WriteLine("God of War|Adventure|Immersive, Hack-n-Slash, third-person| 25.00|25");
        writer.WriteLine("Ghosts of Tsushima|Open World|RPG, Third Person, Adventure|19.99|25");
        writer.WriteLine("Battlefield 1|FPS|Multiplayer, Competitive, WWI|15.00|25");
        writer.WriteLine("GTA: V|Multiplayer|Open World, FPS, Immersive|20.00|25");
        writer.WriteLine("DOOM|FPS|Fast-Paced, Gory, Single-Player|19.99|25");
        writer.Close();
    }

    //Read text file list to object list
    StreamReader reader = new StreamReader(filepath);
    while (true)
    {
        string line = reader.ReadLine();
        if (line == null)
        {
            break;
        }
        else
        {
            string[] parts = line.Split("|");
            Videogame c = new Videogame(parts[0], parts[1], parts[2], decimal.Parse(parts[3]), int.Parse(parts[4]));
            videogames.Add(c);
        }
    }
    reader.Close();

    //decimal to keep a running total
    decimal runningTotal = 0;

    //sales tax constant 
    const decimal tax = 0.06m;
    List<Videogame> cartlist = new List<Videogame>();
    //List
    //start order loop
    bool runProgram = true;
    while (runProgram)
    {
        Console.WriteLine(string.Format("{0, -24} {1, -15} {2, -40} {3, 9} {4, 16}", "Title", "Genre", "Tags", "Price", "Quantity"));
        Console.WriteLine(string.Format("{0, -24} {1, -15} {2, -40} {3, 10} {4, 15}", "===========", "==========", "=============================", "======", "========"));
        //Displays list
        for (int i = 0; i < videogames.Count; i++)
        {
            Console.WriteLine($"{i + 1,-2}. {videogames[i].ToString()}"); //the -2 here sets the minimum width of the index
        }

        //Get user input
        //Get the game they'd like 
        Console.Write("\nWould you like to purchase a game? Please enter its menu number: ");
        int choice = Validator.GetInputInt(1, 12, "Please enter a valid menu choice");
        string choice2 = videogames[choice - 1].ToString();
        Console.WriteLine($"Great! You've selected {videogames[choice - 1].name}.");

        //make separate var to store actual videogame object
        Videogame userChoice = videogames[choice - 1];

        //Get quantity
        Console.Write("How many copies would you like to purchase? ");
        int quantityChoice = Validator.GetInputInt();
         while (quantityChoice > userChoice.quantity)
         {
            quantityChoice = Validator.GetInputInt($"We only have {userChoice.quantity} copies left. Please try again.");
         }  
        userChoice.quantity -= quantityChoice; //update stock
        // Adds desired games and quantity to list
        for (int i = 0; i < quantityChoice; i++)
        {
            cartlist.Add(userChoice);
        }

        //increment our total for each purchase
        decimal currentPurchase = Videogame.AddPurchase(userChoice, quantityChoice);
        runningTotal += currentPurchase;

        //Pass input into purchase method
        Console.WriteLine("Thank you! That will be $" + Videogame.AddPurchase(userChoice, quantityChoice));
        Console.WriteLine($"Your running total is {runningTotal:C}");

        //update list 
        StreamWriter update = new StreamWriter(filepath); //will upate current list 
        foreach (Videogame v in videogames) { }
        update.Close();

        //see if user would like to keep shopping
        runProgram = Validator.GetContinue("Would you like to purchase any other games?");
        Console.Clear();
    }

    //Prints out subtotal, tax, grandtotal
    Console.WriteLine(Videogame.GrandTotalPrint(runningTotal, tax));

    //Valid Payment choices 
    List<string> paymentoptions = new List<string>()
    {
        "cash",
        "credit",
        "check"
    };

    //create grand total variable for math
    decimal grandTotal = Videogame.GrandTotalAmount(runningTotal, tax);

    //Asks for payment type + validate
    Console.WriteLine("How would you like to pay? Please enter cash, check, or credit");
    string paymentchoice = Validator.GetValidString(paymentoptions);

    //payment type logic
    //cash logic 
    if (paymentchoice == "cash")
    {
        Console.WriteLine("How much cash are you providing?");
        decimal cashPayment = Validator.GetInputDecimal(grandTotal, "Please try again. Invalid input or insufficient funds.");
        decimal customerChange = Videogame.GetChange(cashPayment, grandTotal); //create change var to use in receipt later
        Console.Clear();
        Videogame.FinalReceipt(cartlist, runningTotal, tax);
        Console.WriteLine($"Thank you for your purchase!\nYou paid {cashPayment:C} in cash.\nYour change is {Videogame.GetChange(cashPayment, grandTotal):C}.");
        Console.WriteLine("====================================");
    }

    //check logic
    else if (paymentchoice == "check")
    {
        Console.WriteLine("Please enter your check number: ");
        string checkNum = Console.ReadLine().Trim();
        Regex pattern = new Regex(@"^[0-9]{4,6}$");
        Match match = pattern.Match(checkNum);
        while (!match.Success)
        {
            Console.WriteLine("Invalid. Please try again");
            checkNum = Console.ReadLine().Trim();
            match = pattern.Match(checkNum);
        }
        Console.Clear();
        Videogame.FinalReceipt(cartlist, runningTotal, tax);
        Console.WriteLine($"Thank you for your purchase!\nPaid with check {checkNum}.");
        Console.WriteLine("====================================");
    }

    //credit logic
    else if (paymentchoice == "credit")
    {
        //card num validation
        Console.Write("Please enter your card number: ");
        string cardNum = Console.ReadLine().Trim();
        Regex pattern = new Regex(@"^[0-9][0-9]{3}[-.\s]?[0-9]{4}[-.\s]?[0-9]{4}[-.\s]?[0-9]{4}$");
        Match match = pattern.Match(cardNum);
        while (!match.Success)
        {
            Console.WriteLine("Invalid card number. Please try again");
            cardNum = Console.ReadLine().Trim();
            match = pattern.Match(cardNum);
        }

        //card expiration date validation
        Console.Write("Expiration date: ");
        string expDate = Console.ReadLine().Trim();
        Regex pattern1 = new Regex(@"^(0[1-9]|1[0-2])[-/.]?(\d{2})$");
        Match match1 = pattern1.Match(expDate);
        while (!match1.Success)
        {
            Console.WriteLine("Invalid expiration date. Please try again");
            expDate = Console.ReadLine().Trim();
            match1 = pattern1.Match(expDate);
        }

        //card CVV validation
        Console.Write("CVV: ");
        string cvv = Console.ReadLine().Trim();
        Regex pattern2 = new Regex(@"^\d{3}$");
        Match match2 = pattern2.Match(cvv);
        while (!match2.Success)
        {
            Console.WriteLine("Invalid CVV. Please try again");
            cvv = Console.ReadLine().Trim();
            match2 = pattern2.Match(cvv);
        }
        Console.Clear();
        Videogame.FinalReceipt(cartlist, runningTotal, tax);
        Console.WriteLine($"Thank you for your purchase!\nPaid with card {cardNum[0]}{cardNum[1]}{cardNum[2]}{cardNum[3]}-****-****-****.");
        Console.WriteLine("====================================");

    }
    runProg = Validator.GetContinue("Would you like to start a new order");
    Console.Clear();

}
File.Delete(filepath);
