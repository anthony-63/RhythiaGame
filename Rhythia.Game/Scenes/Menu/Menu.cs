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
    public Label FPSLabel = new() {
        TextColor = Color.Green,
        FontSpacing = 2,
        FontSize = 24,
        AlignmentX = TextAlignX.Left,
        AlignmentY = TextAlignY.Top,
    };

    public MenuScene() {
        TestUI.Children.Add(new UiElement {
            Size = new UDim2(1, 0, 1, 0),
            Children = {
                new Frame {
                    Size = new UDim2(0.2f, 0, 0.2f, 0),
                    Position = new UDim2(0.5f, 0, 0.5f, 0),
                    Anchor = UiElementAnchor.Center,
                    Color = Color.White,
                    Children = {
                        new Frame {
                            Size = new UDim2(0.8f, 0, 0.8f, 0),
                            Position = new UDim2(0.5f, 0, 0.5f, 0),
                            Color = Color.Brown,
                            Anchor = UiElementAnchor.Center,
                            BorderWidth = 4,
                            Roundness = 0.2f,
                        },
                    }
                },
                new Label {
                    Size = new UDim2(1, 0, 1, 0),
                    Text = "Test Label 0\nNew Line",
                    FontSize = 18,
                    AlignmentX = TextAlignX.Left,
                    AlignmentY = TextAlignY.Bottom
                },
                new Label {
                    Size = new UDim2(1, 0, 1, 0),
                    Text = "Test Label 1\nNew Line",
                    FontSize = 24,
                    AlignmentX = TextAlignX.Center,
                    AlignmentY = TextAlignY.Middle
                },
                new Label {
                    Size = new UDim2(1, 0, 1, 0),
                    Text = "Test Label 2\nNew Line",
                    FontSize = 32,
                    AlignmentX = TextAlignX.Right,
                    AlignmentY = TextAlignY.Top
                },
                new Label {
                    Size = new UDim2(0, 96, 1, 0),
                    Text = "Wrapping Label testtesttesttesttesttesttesttest",
                    TextWrapped = true,
                    FontSize = 24,
                    AlignmentX = TextAlignX.Left,
                    AlignmentY = TextAlignY.Middle
                },
                new Label {
                    Size = new UDim2(0, 96, 1, 0),
                    Position = new UDim2(1, -96, 0, 0),
                    Text = "Wrapping Label 2 testtesttesttesttesttesttesttest",
                    TextWrapped = true,
                    FontSize = 24,
                    AlignmentX = TextAlignX.Right,
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