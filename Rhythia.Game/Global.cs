using Raylib_cs;
using Rhythia.Content.Beatmaps;
using Rhythia.Content.Settings;

namespace Rhythia.Game;

public static class Global
{
    public static IBeatmapSet? DemoMap;


    public static Settings Settings = new Settings();

    public static Color[] Colors = [Color.White, Color.Pink];
}