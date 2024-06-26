using System.Runtime.InteropServices;
using Raylib_cs;
using Rhythia.Engine;
using Rhythia.Engine.Audio;

namespace Rhythia.Game.Scenes.Game.NoteObject;

public class NoteObjectSpawner
{
    public NoteObject[] OrderedNotes = [];
    
    NoteObject? NextNote = null;
    NoteObject? LastNote = null;

    // int SkippedNotes = 0;
    int StartProcess = 0;

    public List<int> ToUpdateIndices = [];

    bool Pushback = false;

    GameScene Game;

    public NoteObjectSpawner(GameScene game)
    {
        Game = game;
        LoadNotes();
    }

    public void Update()
    {
        UpdateNotes(Game?.Music ?? null);
        UpdateRenderer(Game?.Renderer, Game?.Music);
    }

    public void UpdateRenderer(NoteObjectRenderer? renderer, SyncAudioPlayer? music)
    {
        if(renderer == null || music == null) return;

        renderer.ToRender.Clear();
        for(int i = StartProcess; i < OrderedNotes.Length; i++)
        {
            var note = OrderedNotes[i];
            if(note.IsVisible(music.Time, music.Speed, Global.Settings.Note.ApproachTime, Pushback))
            {
                renderer.ToRender.Add(note);
            }
            if(note.Time > music.Time + Global.Settings.Note.ApproachTime * music.Speed) break;
        }
    }

    public void UpdateNotes(SyncAudioPlayer? music)
    {
        if(music == null) return;

        ToUpdateIndices.Clear();

        for(int i = StartProcess; i < OrderedNotes.Length; i++)
        {
            var note = OrderedNotes[i];
            if(note.CalculateTime(music.Time, Global.Settings.Note.ApproachTime * music.Speed) <= 0 && !note.Hit)
            {
                ToUpdateIndices.Add(i);
            }
            if(note.Time > music.Time + Global.Settings.Note.ApproachTime * music.Speed) break;
        }

        foreach(int i in ToUpdateIndices)
        {
            var didHitreg = false;

            if(false) // check note being hit
            {
                // OrderedNotes[i].Hit = true;
                // didHitreg = true;
            }

            if(!OrderedNotes[i].Hit && OrderedNotes[i].InHitWindow(music.Time, music.Speed)) // miss
            {
                OrderedNotes[i].Hit = true;
                didHitreg = true;
            }

            if(didHitreg)
            {
                LastNote = OrderedNotes[i];

                if(OrderedNotes[i].Index < OrderedNotes.Length - 1)
                {
                    NextNote = OrderedNotes[OrderedNotes[i].Index + 1];
                    StartProcess++;
                }
                else NextNote = null;
            }
        }
    }

    void LoadNotes()
    {
        OrderedNotes = new NoteObject[Global.DemoMap?.Difficulties[0].Notes.Length ?? 1];

        for(int i = 0; i < (Global.DemoMap?.Difficulties[0].Notes.Length ?? 0); i++)
        {
            var noteData = Global.DemoMap?.Difficulties[0].Notes[i] ?? new Content.Beatmaps.Note();
            OrderedNotes[i] = new NoteObject(noteData, i, Global.Colors[i % Global.Colors.Length]);
        }

        Console.WriteLine($"Loaded {OrderedNotes.Length} Notes");
    }
}