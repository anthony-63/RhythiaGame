using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using Rhythia.Engine.Scene;

namespace Rhythia.Engine;

public class Window : GameWindow
{
    public SceneHandler SceneHandler = new SceneHandler();

    public Window(int width, int height, string title) : base(GameWindowSettings.Default, new NativeWindowSettings(){ Size = (width, height), Title = title })
    {

    }

    protected override void OnLoad()
    {
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(Color4.Black);
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        SceneHandler.UpdateAllScenes(this, e.Time);
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);

        GL.Clear(ClearBufferMask.ColorBufferBit);

        SceneHandler.RenderAllScenes(this);

        SwapBuffers();
    }

    protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
    {
        base.OnFramebufferResize(e);
        GL.Viewport(0, 0, e.Width, e.Height);
        
    }
}