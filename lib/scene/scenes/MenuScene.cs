using Console_App_Game;
using System;
using static System.Console;

public class MenuScene : Scene
{
    public MenuScene(Game game) : base(game)
    {
        Draw();
    }

    string[] options = { "New Game", "Load Game", "Exit" };

    int selection = 0;
    bool hasSelection = false;

    public override void Draw()
    {
        WriteLine("========================================");
        for (int i = 0; i < options.Length; i++)
        {
            WriteLine("{0} {1}", (i == selection) ? ">" : " ", options[i]);
        }
        WriteLine("========================================");
    }

    public override bool PostUpdate()
    {
        if (hasSelection)
        {
            switch (selection)
            {
                case 0:
                    Clear();
                    WriteLine("[New Game Scene]");
                    _game.sceneHandler.ChangeScene(new BattleScene(_game));
                    break;
                case 1:
                    Clear();
                    WriteLine("[Load Game Scene]");
                    break;
                case 2:
                    Clear();
                    WriteLine("[Exit] Thanks for playing! :D");
                    ReadKey(true);
                    return false;
                default:
                    return false;
            }
            hasSelection = false;
        }

        return true;
    }

    public override bool Update()
    {
        ConsoleKey key = ReadKey(true).Key;

        if (key == ConsoleKey.UpArrow)
        {
            selection--;
            if (selection < 0)
                selection = 0;
        }
        else if (key == ConsoleKey.DownArrow)
        {
            selection++;
            if (selection > 2)
                selection = 2;
        }
        else if (key == ConsoleKey.Enter)
        {
            hasSelection = true;
        }

        return true;
    }
}



