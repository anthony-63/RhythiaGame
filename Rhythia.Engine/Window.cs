using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Rhythia.Engine;

public class Window : GameWindow {
    public IScene[] Scenes;
    public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title }) {
        Scenes = [];
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        foreach(var scene in Scenes) {
            scene.Update(e.Time);
            scene.Render();
        }
    }
}