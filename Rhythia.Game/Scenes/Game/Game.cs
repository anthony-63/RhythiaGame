using System.Numerics;
using Raylib_cs;
using Rhythia.Engine;
using Rhythia.Engine.Audio;
using Rhythia.Engine.GFX;
using Rhythia.Engine.Scene;
using Rhythia.Game.Scenes.Game.NoteObject;

namespace Rhythia.Game.Scenes.Game;

public class GameScene : IScene
{
    public Camera Camera = new Camera(new Vector3(0, 0, -7), 70);
    public Sprite Grid = Sprite.MakePlane(new Vector3(0, 0, 0), new Vector3(90, 0, 0), new Vector2(6, 6), "Assets/Game/Grid.png");

    public AudioPlayer Music = new AudioPlayer(Global.DemoMap?.AudioData ?? [], 0.1f);

    public NoteObjectSpawner? Spawner = null;
    public NoteObjectRenderer? Renderer = null;

    public void Update(Window window, double dt)
    {
        Spawner ??= new NoteObjectSpawner(this);
        Renderer ??= new NoteObjectRenderer(this);

        if(!Music.Playing) Music.Play();
        else Music.Update();

        Spawner.Update();
    }

    public void Render(Window window)
    {
        Camera.Start();
        Grid.Render();
        Renderer?.RenderNotesSingle();
        Camera.End();
        Raylib.DrawText($"{Renderer?.ToRender.Count}", 10, 10, 16, Color.White);
    }
}