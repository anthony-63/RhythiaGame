using System.Numerics;
using Microsoft.VisualBasic;
using Raylib_cs;
using Rhythia.Content.Settings;
using Rhythia.Engine;
using Rhythia.Engine.GFX;

namespace Rhythia.Game.Scenes.Game.Player;

public class Cursor {

    private float CLAMP = (6.0f - 0.525f) / 2.0f;

    public Sprite Sprite;

    public Vector2 Position = Vector2.Zero;

    public Cursor(Vector3 initialPosition, Vector3 rotation, Vector2 scale, string texPath) {
        Sprite = Sprite.MakePlane(initialPosition, rotation, scale, texPath);
    }

    public void Render() {
        Sprite.Render();
    }

    public void ProcessInput() {
        var sensFactor = Global.Settings.Cursor.Sensitivity / 50f;

        var delta = Vector2.One * (InputManager.MouseDelta * sensFactor);

        Position -= delta;
        if(Global.Settings.Cursor.Clamped) Position = Vector2.Clamp(Position, Vector2.One * -CLAMP, Vector2.One * CLAMP);
    
        Sprite.Position = new Vector3(Position.X, 0f, Position.Y);
    }
}