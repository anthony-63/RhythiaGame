using System.Numerics;
using Rhythia.Engine.GFX;

namespace Rhythia.Game.Scenes.Game.Player;

public class Player
{
    public Score Score = new Score();
    public Camera Camera = new Camera(new Vector3(0, 0, 7), 70f);
    public Cursor Cursor = new Cursor(Vector3.Zero, new Vector3(90, 0, 180), Vector2.One * Global.Settings.Cursor.Scale, "Assets/Game/Cursor.png");

    public void StartRender()
    {
        Camera.Start();
        Cursor.Render();
    }

    public void Update()
    {
        Cursor.ProcessInput();
    }

    public void EndRender()
    {
        Camera.End();
    }
}