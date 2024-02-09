//Welcome
using GCMidterm;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using Validtor;
Console.WriteLine("Welcome to the videogame store!");

//Create + Print list of games
List<Videogame> videogames = new List<Videogame>();
videogames.AddRange(new List<Videogame>
{
    new Videogame("Celeste", "Platformer", "Challenging, Pixel Art, Indie",  19.99m),
    new Videogame("Hollow Knight", "Metroidvania", "Challenging, Action, Indie",  14.99m),
    new Videogame("Apex Legends", "FPS", "Multiplayer, Competitive, F2P",  0.00m),
    new Videogame("Pokemon Crystal", "RPG", "Immersive, Pixel Art, Adventure",  75.00m),
    new Videogame("Factorio", "Factory Builder", "Immersive, Problem-Solving, 2D",  35.00m),
    new Videogame("Super Meat Boy", "Platformer", "Challenging, Pixel Art, Indie",  14.99m),
    new Videogame("Elden Ring", "Souls-like", "Challenging, Open-World, Immersive",  60.00m),
    new Videogame("God of War", "Adventure", "Immersive, Hack-n-Slash, third-person",  25.00m),
    new Videogame("Ghosts of Tsushima ", "Open World", "RPG, Third Person , Adventure",  35.00m),
    new Videogame("BattleField 1", "FPS", "Multiplayer, Competive, WWI",  15.00m),
    new Videogame("GTA:V", "Multiplayer", "Open World, FPS, Immersive",  20.00m),
    new Videogame("DOOM", "FPS", "Fast-Paced, Gory, Single-Player",  19.99m),
});

//decimal to keep a running total
decimal runningTotal = 0;

//sales tax constant 
const decimal tax = 0.06m;
List<Videogame> cartlist = new List<Videogame>();
//List
//start infinite program loop
bool runProgram = true;
while (runProgram)
{

    //Displays list
    for (int i = 0; i < videogames.Count; i++)
    {
        Console.WriteLine($"{i + 1,-2}. {videogames[i].ToString()}"); //the -2 here sets the minimum width of the index
    }

    //Get user input
    //Get the game they'd like 
    Console.Write("Would you like to purchase a game? Please enter its menu number: ");
    int choice = Validator.GetInputInt(1, 12, "Please enter a valid menu choice");
    string choice2 = videogames[choice - 1].ToString();
    Console.WriteLine($"Great! You've selected {videogames[choice - 1].name}.");

    //make separate var to store actual videogame object
    Videogame userChoice = videogames[choice - 1];
    //Userchoice1 = userChoice;
    Console.WriteLine(userChoice.ToString());
    //Get quantity
    Console.Write("How many copies would you like to purchase? ");
    int quantityChoice = Validator.GetInputInt();
  
    // Adds desired games and quantity to list
    for (int i = 0;i< quantityChoice;i++)
    {
     cartlist.Add(userChoice);
    }

    //increment our total for each purchase
    decimal currentPurchase = Videogame.AddPurchase(userChoice, quantityChoice);
    runningTotal += currentPurchase;

    //Pass input into purchase method
    Console.WriteLine("Thank you! That will be: $" + Videogame.AddPurchase(userChoice, quantityChoice));
    Console.WriteLine($"Your running total is {runningTotal:C}");

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
    Console.Clear(); 
    decimal customerChange = Videogame.GetChange(cashPayment, grandTotal); //create change var to use in receipt later
    Videogame.FinalReceiptCash(cartlist, runningTotal, tax);
    Console.WriteLine($"Thank you for your order! You paid {cashPayment:C} \nYour change is {Videogame.GetChange(cashPayment, grandTotal):C}");
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

}

  