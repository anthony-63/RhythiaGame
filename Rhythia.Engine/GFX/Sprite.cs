using System.Numerics;
using Raylib_cs;

namespace Rhythia.Engine.GFX;

public class Sprite
{
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector2 Size;
    public Model Model;
    
    public static Sprite MakePlane(Vector3 position, Vector3 rotation, Vector2 size, string texturePath)
    {
        Sprite sprite = new Sprite
        {
            Position = position,
            Rotation = rotation,
            Size = size,
        };

        Model model = Raylib.LoadModelFromMesh(Raylib.GenMeshPlane(size.X, size.Y, 1, 1));

        Image img = Raylib.LoadImage(texturePath);
        Texture2D texture = Raylib.LoadTextureFromImage(img);
        
        Raylib.UnloadImage(img);

        Raylib.SetMaterialTexture(ref model, 0, MaterialMapIndex.Diffuse, ref texture);

        sprite.Model = model;

        return sprite;
    }

    public void Render()
    {
        Rlgl.PushMatrix();
        Rlgl.Rotatef(Rotation.X, 1f, 0f, 0f);
        Rlgl.Rotatef(Rotation.Y, 0f, 1f, 0f);
        Rlgl.Rotatef(Rotation.Z, 0f, 0f, 1f);
        Raylib.DrawModel(Model, Position, 1, Color.White);
        Rlgl.PopMatrix();
    }
}