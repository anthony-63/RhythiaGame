using System;

using Rhythia.Engine;
using Rhythia.Game.Scenes.Game;

namespace Rhythia.Game;

public class Program
{
    static void Main(string[] args)
    {
        var window = new Window(1280, 720, "NewRhythia");
        window.SceneHandler.AddScene(new GameScene());
        // window.Run();
    }
}