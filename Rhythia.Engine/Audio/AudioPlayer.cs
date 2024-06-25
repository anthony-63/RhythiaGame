using Raylib_cs;

namespace Rhythia.Engine.Audio;

public class AudioPlayer
{
    public Music AudioStream;

    private byte[] AudioData = {};

    public float Time => Raylib.GetMusicTimePlayed(AudioStream);
    public bool Playing => Raylib.IsMusicStreamPlaying(AudioStream);

    public float Speed = 1f;

    public AudioPlayer(string path, float volume, float speed = 1f)
    {
        AudioStream = Raylib.LoadMusicStream(path);
        Raylib.SetMusicVolume(AudioStream, volume);
        Raylib.SetMusicPitch(AudioStream, speed);
        Speed = speed;
    }

    public AudioPlayer(byte[] data, float volume, float speed = 1f)
    {
        AudioData = data;
        AudioStream = Raylib.LoadMusicStreamFromMemory(GetFileFormat(AudioData), AudioData);
        Raylib.SetMusicVolume(AudioStream, volume);
        Raylib.SetMusicPitch(AudioStream, speed);
        Speed = speed;
    }

    public void Play()
    {
        Raylib.PlayMusicStream(AudioStream);
    }

    public void Play(float from)
    {
        Raylib.PlayMusicStream(AudioStream);
        Raylib.SeekMusicStream(AudioStream, from);
    }

    public void Seek(float from)
    {
        Raylib.SeekMusicStream(AudioStream, from);
    }

    public void Update()
    {
        Raylib.UpdateMusicStream(AudioStream);
    }

    private static string GetFileFormat(byte[] bytes)
	{
		if (bytes.Length < 10) return "unknown";
		if (bytes[0] == 0x52 && bytes[1] == 0x49 && bytes[2] == 0x46 && bytes[3] == 0x46) return ".wav";
		if ((bytes[0] == 0xFF && (bytes[1] == 0xFB || (bytes[1] == 0xFA && bytes[2] == 0x90))) || (bytes[0] == 0x49 && bytes[1] == 0x44 && bytes[2] == 0x33)) return ".mp3";
		if (bytes[0] == 0x4F && bytes[1] == 0x67 && bytes[2] == 0x67 && bytes[3] == 0x53) return ".ogg";
		return "unknown";
	}
}