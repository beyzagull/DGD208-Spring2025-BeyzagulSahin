using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {

        Console.Title = "Whimsical Pet Realms";
        Game game = new Game();
        await game.GameLoop();
    }
}
