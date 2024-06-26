using Rhythia.Engine.Scene;

using Raylib_cs;

namespace Rhythia.Engine;

public class Window
{
    public SceneHandler SceneHandler = new SceneHandler();

    public Window(int width, int height, string title)
    {
        Raylib.InitAudioDevice();
        Logger.Info("Initialized Audio");
        
        Raylib.InitWindow(width, height, title);
        Logger.Info("Initialized Window");
    }

    public void Run()
    {
        while(!Raylib.WindowShouldClose())
        {
            Raylib.PollInputEvents();
            SceneHandler.UpdateAllScenes(this, Raylib.GetFrameTime());

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Black);

            SceneHandler.RenderAllScenes(this);

            Raylib.EndDrawing();
        }
    }
}