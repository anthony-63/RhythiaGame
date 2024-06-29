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
    public Label FPSLabel = new()
    {
        // FontSpacing = 1,
        FontSize = 24,
        AlignmentX = TextAlignX.Left,
        AlignmentY = TextAlignY.Top,
    };

    public MenuScene() {
        TestUI.Children.Add(new UiElement {
            Size = new UDim2(0.5f, 0 ,0.5f, 0),
            Children = {
                new Label {
                    Size = new UDim2(1, 0, 1, 0),
                    Text = "Test Label 1",
                    FontSize = 24,
                    AlignmentX = TextAlignX.Center,
                    AlignmentY = TextAlignY.Middle
                }
            }
        });
        TestUI.Children.Add(FPSLabel);
    }

    public void Render(Window window) {
        TestUI.Render(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
    }

    public void Update(Window window, double dt) {
        FPSLabel.Text = $"FPS: {Raylib.GetFPS()}";
        TestUI.Update(dt);
    }
}