using System;

using Rhythia.Engine;

namespace Rhythia.Game;

public class Program
{
    static void Main(string[] args)
    {
        using (Window game = new Window(1280, 720, "NewRhythia"))
        {
            game.Run();
        }
    }
}