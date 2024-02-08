//Welcome
using GCMidterm;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
    Console.WriteLine(userChoice.ToString());

    //Get quantity
    Console.Write("How many copies would you like to purchase? ");
    int quantityChoice = Validator.GetInputInt();

    //increment our total for each purchase
    decimal currentPurchase = Videogame.AddPurchase(userChoice, quantityChoice);
    runningTotal += currentPurchase;

    //Pass input into purchase method
    Console.WriteLine("Thank you! That will be: $" + Videogame.AddPurchase(userChoice, quantityChoice));
    Console.WriteLine($"Your running total is {runningTotal:C}");

    //see if user would like to keep shopping
    runProgram = Validator.GetContinue("Would you like to purchase any other games?");
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
if (paymentchoice == "cash")
{
    Console.WriteLine("How much cash are you providing?");
    decimal cashPayment = Validator.GetInputDecimal(grandTotal, "Please try again. Invalid input or insufficient funds.");
    decimal customerChange = Videogame.GetChange(cashPayment, grandTotal); //create change var to use in receipt later
    Console.WriteLine($"Thank you for your order! Your change is: {Videogame.GetChange(cashPayment, grandTotal):C}");
}
//else if (paymentchoice == "check")
//{
//    Console.Write("What is your check number: ");
//    int checkNum = int.Parse(Console.ReadLine().Trim());
//    checkNum = Validator.GetInputInt(4, 6);

//}

