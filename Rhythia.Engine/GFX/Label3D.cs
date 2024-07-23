using System.Numerics;
using Raylib_cs;
using Rhythia.Engine.UI.Elements;

namespace Rhythia.Engine.GFX;

public class Label3D {
    public Label Label2D;
    private RenderTexture2D RenderTexture;

    Sprite Sprite;

    public Label3D(Label label2D) {
        Label2D = label2D;

        
        Sprite = Sprite.MakePlane(new Vector3(0f), new Vector3(0f), new Vector2(100, 100), RenderTexture.Texture);
    }
}