public class SceneHandler
{
    private Scene _currentScene;
    private Scene _nextScene;

    public void ChangeScene(Scene scene)
    {
        _nextScene = scene;
    }

    public void Start(Scene scene)
    {
        _currentScene = scene;
    }

    public bool Update()
    {
        if (_nextScene != null)
        {
            _currentScene = _nextScene;
            _nextScene = null;
        }

        return _currentScene.Update();
    }

    public void Draw()
    {
        _currentScene.Draw();
    }

    public bool PostUpdate()
    {
        return _currentScene.PostUpdate();
    }
}