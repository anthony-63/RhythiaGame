using System;
using Raylib_cs;
using Rhythia.Engine;
using Rhythia.Game.Scenes.Game;

namespace Rhythia.Game;

public class Program
{
    static void Main(string[] args)
    {
        Logger.Init("rhythia.log");
        var window = new Window(1280, 720, "NewRhythia");
        window.SceneHandler.AddScene(new LoadingScene());
        window.Run();
    }
}