namespace Rhythia.Content.Beatmaps;

public interface IBeatmapSet {
    ushort Version { get; set; }
    String Title { get; set; }
    String Artist { get; set; }
    String[] Mappers { get; set; }

    Beatmap[] Difficulties { get; set; }

    byte[] AudioData { get; set;}

   string Path { get; set; }
}