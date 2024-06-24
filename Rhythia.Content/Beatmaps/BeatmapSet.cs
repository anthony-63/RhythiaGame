using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Rhythia.Content.Beatmaps;

public class BeatmapSet : IBeatmapSet
{
    public ushort Version { get; set; }
    public string Title { get; set; } = "";
    public string Artist { get; set; } = "";
    public string[] Mappers { get; set; } = new string[0];
    public Beatmap[] Difficulties { get; set; } = new Beatmap[0];
    
    public string Path { get; set; } = "";

    public BeatmapSet(string folderPath)
    {
        Path = folderPath;

        var metaDoc = JsonDocument.Parse(File.ReadAllText(folderPath + "/meta.json"));

        Version = metaDoc.RootElement.GetProperty("_version").GetUInt16();
        Title = metaDoc.RootElement.GetProperty("_title").GetString() ?? throw new JsonException("Failed to parse _title");
        Mappers = metaDoc.RootElement.GetProperty("_mappers").EnumerateArray().Select(elem => elem.GetString() ?? throw new JsonException("Failed to parse _mappers")).ToArray();
        Difficulties = GetDifficulties(metaDoc.RootElement.GetProperty("_difficulties").EnumerateArray().Select(elem => elem.GetString() ?? throw new JsonException("Failed to parse _difficulties")).ToArray());
    }

    Beatmap[] GetDifficulties(string[] files)
    {
        var beatmaps = new Beatmap[files.Length];

        for(int i = 0; i < files.Length; i++)
        {
            beatmaps[i] = new Beatmap();

            var diffDoc = JsonDocument.Parse(File.ReadAllText(Path + "/" + files[i]));
            beatmaps[i].Name = diffDoc.RootElement.GetProperty("_name").GetString() ?? throw new JsonException("Failed to parse _name in difficulty " + files[i]);
            
            var noteElements = diffDoc.RootElement.GetProperty("_notes").EnumerateArray().ToArray();
            beatmaps[i].Notes = new Note[noteElements.Length];
            foreach(JsonElement noteElem in noteElements)
            {
                beatmaps[i].Notes[i].Time = noteElem.GetProperty("_time").GetSingle();
                beatmaps[i].Notes[i].X = noteElem.GetProperty("_x").GetSingle();
                beatmaps[i].Notes[i].Y = noteElem.GetProperty("_y").GetSingle();
            }
        }
        return beatmaps;
    }
}