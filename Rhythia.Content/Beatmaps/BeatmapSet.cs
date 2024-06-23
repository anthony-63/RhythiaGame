namespace Rhythia.Content.Beatmaps;

public class BeatmapSet : IBeatmapSet
{
    public required ushort Version { get; set; }
    public string Title { get; set; } = "";
    public string Artist { get; set; } = "";
    public string[] Mappers { get; set; } = new string[0];
    public Beatmap[] Difficulties { get; set; } = new Beatmap[0];
    
    public string? Path { get; set; }
}