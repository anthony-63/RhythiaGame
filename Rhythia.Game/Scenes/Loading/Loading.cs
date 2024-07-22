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

        Global.SelectedMap = null;
        MapLoader.LoadMaps("Assets/maps");

        window.SceneHandler.RemoveSceneByType<LoadingScene>();
        window.SceneHandler.AddScene(new GameScene());
    }
}