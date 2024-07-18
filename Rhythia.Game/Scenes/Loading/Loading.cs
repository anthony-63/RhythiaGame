using Rhythia.Content.Beatmaps;
using Rhythia.Content.Settings;
using Rhythia.Engine;
using Rhythia.Engine.Scene;
using Rhythia.Game.Scenes.Game;
using Rhythia.Game.Scenes.Menu;

namespace Rhythia.Game.Scenes.Loading;

public class LoadingScene : IScene {
    public void Render(Window window) {}

    public void Update(Window window, double dt) {
        Global.Settings = Settings.Load("Assets/settings.json");

        Global.DemoMap = new BeatmapSet("Assets/DemoMap");

        window.SceneHandler.RemoveSceneByType<LoadingScene>();
        window.SceneHandler.AddScene(new MenuScene());
    }
}