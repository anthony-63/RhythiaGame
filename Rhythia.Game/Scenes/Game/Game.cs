using System.Numerics;
using Rhythia.Engine;
using Rhythia.Engine.Audio;
using Rhythia.Engine.GFX;
using Rhythia.Engine.Scene;

namespace Rhythia.Game.Scenes.Game;

public class GameScene : IScene
{
    Camera Camera = new Camera(new Vector3(0, 0, -7), 70);
    Sprite Grid = Sprite.MakePlane(new Vector3(0, 0, 0), new Vector3(90, 0, 0), new Vector2(6, 6), "Assets/Game/Grid.png");

    AudioPlayer Music = new AudioPlayer(Global.DemoMap?.AudioData ?? [], 0.1f);

    public void Update(Window window, double dt)
    {
        if(!Music.Playing) Music.Play();
        else Music.Update();
    }

    public void Render(Window window)
    {
        Camera.Start();
        Grid.Render();
        Camera.End();
    }
}