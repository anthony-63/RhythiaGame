using System.Numerics;
using Raylib_cs;
using Rhythia.Content.Beatmaps;

namespace Rhythia.Game.Scenes.Game.NoteObject;

public class NoteObject {
    public const float HitWindow = 0.055f;
    public const float AABB = (1.75f + 0.525f) / 2.0f;

    public Note Note;

    public bool Hit = false;
    public int Index = -1;
    public Color Color;

    public float Time => Note.Time;
    public float X => Note.X * 2f;
    public float Y => Note.Y * 2f;

    public NoteObject(Note note, int index, Color color) {
        Note = note;
        Index = index;
        Color = color;
    }

    public bool InHitWindow(float Time, float Speed) {
        return (Time - Note.Time) <= HitWindow * Speed;
    }

    public bool IsVisible(float Time, float Speed, float ApproachTime, bool Pushback) {
        if(Hit) return false;
        if(Time > Note.Time && !Pushback) return false;
        return CalculateTime(Time, ApproachTime) <= 1f && InHitWindow(Time, Speed);
    }

    public float CalculateTime(float Time, float ApproachTime) {
        return (Note.Time - Time) / ApproachTime;
    }

    public bool IsHitting(Vector2 cursorPosition) {
        return Math.Abs(-cursorPosition.X - X) <= AABB && Math.Abs(cursorPosition.Y - Y) <= AABB;
    }
}