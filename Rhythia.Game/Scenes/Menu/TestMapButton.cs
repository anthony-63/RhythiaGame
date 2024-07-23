using Rhythia.Content.Beatmaps;
using Rhythia.Engine;
using Rhythia.Engine.UI.Elements;
using Rhythia.Game.Scenes.Game;

namespace Rhythia.Game.Scenes.Menu;

public class TestMapButton : Button {
    public IBeatmapSet Map;
    public void CheckPressed(Window window) {
        if(State == ButtonState.Pressed) {
            Global.SelectedMap = Map;
            window.SceneHandler.RemoveSceneByType<MenuScene>();
            window.SceneHandler.AddScene(new GameScene());
        }
    }
}