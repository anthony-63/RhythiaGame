using System.Numerics;
using Rhythia.Engine.GFX;
using Rhythia.Game.Scenes.Game.NoteObject;

namespace Rhythia.Game.Scenes.Game.Player;

public class Player
{
    public Score Score = new();
    public Camera Camera = new(new Vector3(0, 0, 7), 70f);
    public Cursor Cursor = new(Vector3.Zero, new Vector3(90, 0, 180), Vector2.One * Global.Settings.Cursor.Scale, "Assets/Game/Cursor.png");

    public void StartRender() {
        Camera.Start();
        Cursor.Render();
    }

    public void Hit(int idx) {
        Score.Hits += 1;
    }
    public void Miss(int idx) {
        Score.Misses += 1;
    }

    public void Update() {
        Cursor.ProcessInput();
    }

    public void EndRender() {
        Camera.End();
    }
}