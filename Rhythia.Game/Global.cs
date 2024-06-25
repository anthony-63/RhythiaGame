using Raylib_cs;
using Rhythia.Content.Beatmaps;

namespace Rhythia.Game;

public static class Global
{
    public static IBeatmapSet? DemoMap;

    public static float ApproachTime = 0.38f;
    public static float ApproachDistance = 14f;
    public static Color[] Colors = [Color.White, Color.Pink];
}