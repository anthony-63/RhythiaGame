using System.Numerics;
using Rhythia.Engine.GFX;

namespace Rhythia.Game.Scenes.Game.NoteObject;

public class NoteObjectRenderer
{
    GameScene Game;

    public List<NoteObject> ToRender = [];

    MultiMesh MultiMesh;

    public NoteObjectRenderer(GameScene game)
    {
        Game = game;
        MultiMesh = new MultiMesh("Assets/Game/Mesh.obj");
    }

    public void RenderNotesSingle()
    {
        if(ToRender.Count < 1) return;

        foreach(var note in ToRender)
        {
            var noteTime = note.CalculateTime(Game.Music?.Time ?? 0, Global.Settings.Note.ApproachTime);
            var noteDist = noteTime * Global.Settings.Note.ApproachDistance;

            var transform = Matrix4x4.Transpose(Matrix4x4.CreateTranslation(
                new Vector3(note.X * 2f, note.Y * 2f, -noteDist)
            ));
            var mat = ColoredMaterialGenerator.GetColoredMaterial(note.Color);

            MultiMesh.AddInstance(transform, mat);
        }

        MultiMesh.Render();
    }
}