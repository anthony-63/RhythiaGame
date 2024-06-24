using System.Numerics;
using Rhythia.Engine;
using Rhythia.Engine.GFX;
using Rhythia.Engine.Scene;

namespace Rhythia.Game.Scenes.Game;

public class GameScene : IScene
{
    Camera Camera = new Camera(new Vector3(0, 0, -7), 70);
    Sprite Grid = Sprite.MakePlane(new Vector3(0, 0, 0), new Vector3(90, 0, 0), new Vector2(6, 6), "Assets/Game/Grid.png");

    public void Update(Window window, double dt)
    {

    }

    public void Render(Window window)
    {
        Camera.Start();
        Grid.Render();
        Camera.End();
    }
}