using Rhythia.Content.Beatmaps;
using Rhythia.Engine;
using Rhythia.Engine.Scene;

namespace Rhythia.Game.Scenes.Game;

public class LoadingScene : IScene
{
    public void Render(Window window)
    {
    }

    public void Update(Window window, double dt)
    {
        Global.DemoMap = new SSPMap("Assets/singularity/singularity.sspm");
        window.SceneHandler.RemoveSceneByType<LoadingScene>();
        window.SceneHandler.AddScene(new GameScene());
    }
}