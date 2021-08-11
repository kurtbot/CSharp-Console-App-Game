using System;
using static System.Console;
using static System.Threading.Thread;

public class BattleScene : Scene
{

    private Entity e1;
    private Entity e2;

    private int turn = 0;
    private int selection = 0;
    private bool hasSelection;

    private string[] options = { "Attack", "Status", "Exit" };

    public BattleScene(Game game) : base(game)
    {
        e1 = new TestCharacter("Player 1");
        e2 = new TestCharacter("Player 2");
        Draw();
    }

    public override void Draw()
    {
        if (turn == 0)
        {
            WriteLine("========================================");
            for (int i = 0; i < options.Length; i++)
            {
                WriteLine("{0} {1}", (i == selection) ? ">" : " ", options[i]);
            }
            WriteLine("========================================");
        }
        else if(turn == 1)
        {
            WriteLine("{0} attacks!", e2.Name);
            Sleep(1500);
        }
    }

    public override bool PostUpdate()
    {

        if (turn == 0 && hasSelection)
        {
            switch (selection)
            {
                case 0:
                    Clear();
                    WriteLine("{0} took {1} damage!", e2.Name, e2.Defend(e1));
                    ReadKey(true);
                    turn = 1;
                    break;
                case 1:
                    Clear();
                    WriteLine("========================================");
                    WriteLine(e1.ToString());
                    WriteLine(e2.ToString());
                    WriteLine("========================================");
                    ReadKey(true);
                    Clear();
                    Draw();
                    break;
                case 2:
                    Clear();
                    _game.sceneHandler.ChangeScene(new MenuScene(_game));
                    break;
                default:
                    return false;
            }
            hasSelection = false;
        }
        else if(turn == 1)
        {
            WriteLine("{0} took {1} damage!", e1.Name, e1.Defend(e2));
            turn = 0;
        }

        if (!e1.IsAlive || !e2.IsAlive)
        {
            Clear();
            if (e1.IsAlive)
            {
                WriteLine("{0} wins!", e1.Name);
                ReadKey(true);
            }
            else
            {
                WriteLine("{0} wins!", e2.Name);
                ReadKey(true);
            }
            return false;
        }

        return true;
    }

    public override bool Update()
    {
        // if (isE1)
        // {
        //     ConsoleKey key = ReadKey(true).Key;

        //     if (key == ConsoleKey.UpArrow)
        //     {
        //         e1Selection--;
        //         if (e1Selection < 0)
        //             e1Selection = 0;
        //     }
        //     else if (key == ConsoleKey.DownArrow)
        //     {
        //         e1Selection++;
        //         if (e1Selection > 2)
        //             e1Selection = 2;
        //     }
        //     else if (key == ConsoleKey.Enter)
        //     {
        //         hasSelection = true;
        //     }
        // }
        // else
        // {

        // }

        if (turn == 0)
        {
            ConsoleKey key = ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                hasSelection = true;
            }
            else if (key == ConsoleKey.DownArrow)
            {
                selection += 1;
                if (selection > options.Length - 1)
                    selection = options.Length - 1;
            }
            else if (key == ConsoleKey.UpArrow)
            {
                selection -= 1;
                if (selection < 0)
                    selection = 0;
            }
        }

        return true;
    }
}