#region Imports
using System;
using static System.Threading.Thread;
using static System.Console;
#endregion

namespace Console_App_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            game.Start();
        }
    }

}
