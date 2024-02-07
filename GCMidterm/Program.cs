//Welcome
using GCMidterm;

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

//Displays list
for (int i = 0; i < videogames.Count; i++)
{
    Console.WriteLine($"{i + 1}. {videogames[i].ToString()}");
}

//Get user input
Console.WriteLine("Would you like to purchase a game?");