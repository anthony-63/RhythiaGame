using System.Numerics;
using Rhythia.Engine.GFX;

namespace Rhythia.Game.Scenes.Game.Player;

public class Player
{
    public Score Score = new Score();
    public Camera Camera = new Camera(new Vector3(0, 0, 7), 70f);
    public Cursor Cursor = new Cursor();

    public void StartRender()
    {
        Camera.Start();
    }

    public void EndRender()
    {
        Camera.End();
    }
}