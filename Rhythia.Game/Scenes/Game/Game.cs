using System.Numerics;
using Raylib_cs;
using Rhythia.Engine;
using Rhythia.Engine.Audio;
using Rhythia.Engine.GFX;
using Rhythia.Engine.Scene;
using Rhythia.Game.Scenes.Game.NoteObject;
using Rhythia.Game.Scenes.Game.Player;

namespace Rhythia.Game.Scenes.Game;

public class GameScene : IScene
{
    public Player.Player Player = new Player.Player();
    public Sprite Grid = Sprite.MakePlane(new Vector3(0, 0, 0), new Vector3(90, 0, 180), new Vector2(6, 6), "Assets/Game/Grid.png");

    public SyncAudioPlayer Music = new SyncAudioPlayer(Global.DemoMap?.AudioData ?? [], 0.1f);

    public NoteObjectSpawner? Spawner = null;
    public NoteObjectRenderer? Renderer = null;

    public GameScene()
    {
        Raylib.DisableCursor();
    }

    public void Update(Window window, double dt)
    {
        Spawner ??= new NoteObjectSpawner(this);
        Renderer ??= new NoteObjectRenderer(this);

        if(!Music.Playing) Music.Play(0f);
        else Music.Update();
        Player.Update();
        Spawner.Update();
    }

    public void Render(Window window)
    {
        Player.StartRender();
        Renderer?.RenderNotesSingle();
        Grid.Render();
        Player.EndRender();
        Raylib.DrawFPS(0, 0);
    }
}