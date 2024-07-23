using Raylib_cs;

namespace Rhythia.Game.Scenes.Game.HUD;

public class Timer {
    public static string Title = Global.SelectedMap?.Title ?? "----------";

    public static float EndTime = Global.SelectedMap?.Difficulties[0].Notes.Last().Time ?? 0f;

    public void DrawTitle() {
    }
}