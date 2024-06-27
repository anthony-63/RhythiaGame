namespace Rhythia.Game.Scenes.Game.HUD;

public class Timer
{
    public static string Title = Global.DemoMap?.Title ?? "----------";

    public static float EndTime = Global.DemoMap?.Difficulties[0].Notes.Last().Time ?? 0f;

    public void DrawTitle()
    {

    }
}