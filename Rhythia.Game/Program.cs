using System;
using Raylib_cs;
using Rhythia.Engine;
using Rhythia.Game.Scenes.Game;
using Rhythia.Game.Scenes.Loading;

namespace Rhythia.Game;

public class Program {
    static void Main(string[] args) {
        Logger.Init("rhythia.log");
        var window = new Window(1280, 720, "NewRhythia");
        window.SceneHandler.AddScene(new LoadingScene());
        window.Run();
        Global.Settings.Save("Assets/settings.json");
    }
}