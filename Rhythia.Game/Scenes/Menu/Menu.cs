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
    public Button TestButton = new() {
        Size = new UDim2(0.2f, 0, 0.2f, 0),
        Position = new UDim2(0f, 40, 0, 40),
        Anchor = UiElementAnchor.TopLeft,
        NormalFrame = new Frame {
            Color = Color.Gray,
        },
        HoveringFrame = new Frame {
            Color = Color.DarkGray,
        },
        PressedFrame = new Frame {
            Color = Color.DarkPurple,
        },
        Label = new Label {
            Size = new UDim2(1f, 0, 1f, 0),
            Position = UDim2.Zero,
            AlignmentX = TextAlignX.Center,
            AlignmentY = TextAlignY.Middle,
        }
    };
    

    public MenuScene() {
        TestUI.Children.Add(new UiElement {
            Size = new UDim2(1, 0, 1, 0),
            Children = {
                new ImageFrame {
                    Size = new UDim2(0f, 100, 0f, 100),
                    Position = new UDim2(0f, 0, 0f, 0),
                    ImagePath = "Assets/Game/cat.png",
                },
                // new Label {
                //     Size = new UDim2(1, 0, 1, 0),
                //     Text = "Test Label 0\nNew Line",
                //     FontSize = 18,
                //     AlignmentX = TextAlignX.Left,
                //     AlignmentY = TextAlignY.Bottom
                // },
                // new Label {
                //     Size = new UDim2(1, 0, 1, 0),
                //     Text = "Test Label 1\nNew Line",
                //     FontSize = 24,
                //     AlignmentX = TextAlignX.Center,
                //     AlignmentY = TextAlignY.Middle
                // },
                new Label {
                    Size = new UDim2(1, 0, 1, 0),
                    Text = "Test Label 2\nNew Line",
                    FontSize = 32,
                    AlignmentX = TextAlignX.Right,
                    AlignmentY = TextAlignY.Top
                },
                // new Label {
                //     Size = new UDim2(0, 96, 1, 0),
                //     Text = "Wrapping Label testtesttesttesttesttesttesttest",
                //     TextWrapped = true,
                //     FontSize = 24,
                //     AlignmentX = TextAlignX.Left,
                //     AlignmentY = TextAlignY.Middle
                // },
                // new Label {
                //     Size = new UDim2(0, 96, 1, 0),
                //     Position = new UDim2(1, -96, 0, 0),
                //     Text = "Wrapping Label 2 testtesttesttesttesttesttesttest",
                //     TextWrapped = true,
                //     FontSize = 24,
                //     AlignmentX = TextAlignX.Right,
                //     AlignmentY = TextAlignY.Middle
                // }
            }
        });
        TestUI.Children.Add(FPSLabel);
        TestUI.Children.Add(TestButton);
    }

    public void Render(Window window) {
        TestUI.Render(Raylib.GetRenderWidth(), Raylib.GetRenderHeight());
    }

    public void Update(Window window, double dt) {
        FPSLabel.Text = $"FPS: {Raylib.GetFPS()}";
        switch(TestButton.State) {
            case ButtonState.Normal: TestButton.Label.Text = "Not Hovering"; break;
            case ButtonState.Hovering: TestButton.Label.Text = "Hovering"; break;
            case ButtonState.Pressed: TestButton.Label.Text = "Pressed"; break;
        }
        TestUI.Update(dt);
    }
}