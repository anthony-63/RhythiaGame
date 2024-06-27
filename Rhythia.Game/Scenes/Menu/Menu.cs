using Raylib_cs;
using Rhythia.Content.Beatmaps;
using Rhythia.Content.Settings;
using Rhythia.Engine;
using Rhythia.Engine.Scene;
using Rhythia.Engine.UI;
using Rhythia.Engine.UI.Elements;

namespace Rhythia.Game.Scenes.Menu;

public class MenuScene : IScene {
    public UiRoot TestUI = new();

    public MenuScene() {
        TestUI.Children.Add(new UiElement {
            Size = new UDim2(0.5f, 0 ,0.5f, 0)
        });
    }

    public void Render(Window window) {
        TestUI.Render(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
    }

    public void Update(Window window, double dt) {
        TestUI.Update(dt);
    }
}