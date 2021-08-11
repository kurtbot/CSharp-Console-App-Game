using System;

public class Game
{

    int turn = 0;
    int selection = 0;
    bool isRunning = true;

    public SceneHandler sceneHandler;

    public Game()
    {
        Console.Clear();
        sceneHandler = new SceneHandler();
        sceneHandler.Start(new MenuScene(this));
    }

    public void Start()
    {
        // main game loop
        do
        {
            // Clear();

            sceneHandler.Update();
            Console.Clear();
            sceneHandler.Draw();
            isRunning = sceneHandler.PostUpdate();

        } while (isRunning);
    }
}