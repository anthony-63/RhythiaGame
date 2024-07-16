using Raylib_cs;

namespace Rhythia.Engine.GFX;

public static class ColoredMaterialGenerator {
    public static Material GetColoredMaterial(Color color) {
        Material material = Raylib.LoadMaterialDefault();

        unsafe {
            material.Maps[(int)MaterialMapIndex.Diffuse].Color = color;
        }

        return material;
    }
}