using Console_App_Game;
using System;

public abstract class Scene
{
    protected Game _game;

    public Scene(Game game)
    {
        _game = game;
    }

    public void WriteLine(string text, params object[] options)
    {
        Console.WriteLine(text, options);
    }

    public void Clear()
    {
        Console.Clear();
    }

    public abstract bool Update();
    public abstract void Draw();
    public abstract bool PostUpdate();
}