using System.Numerics;
using Raylib_cs;

namespace Rhythia.Engine.GFX;

struct MeshInstance
{
    public Material Material;
    public Matrix4x4 Transform;
}

public class MultiMesh
{
    Mesh Mesh;

    List<MeshInstance> Instances = new List<MeshInstance>();

    int Count;

    public MultiMesh(string meshPath)
    {
        var model = Raylib.LoadModel(meshPath);
        unsafe
        {
            Mesh = model.Meshes[0];
        }
    }

    public void AddInstance(Matrix4x4 transform, Material material)
    {
        Instances.Add(new MeshInstance()
        {
            Material = material,
            Transform = transform,
        });
    }

    public void Render()
    {
        foreach(var instance in Instances)
        {
            Raylib.DrawMesh(Mesh, instance.Material, instance.Transform);
        }
        Instances.Clear();
    }
}