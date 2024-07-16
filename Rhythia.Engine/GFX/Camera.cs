using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

namespace Rhythia.Engine.GFX;

public class Camera {
    Camera3D RlCamera;

    public Camera(Vector3 position, float fov) {
        RlCamera = new Camera3D(
            position,
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            fov,
            CameraProjection.Perspective
        );
    }

    public void Start() {
        Raylib.BeginMode3D(RlCamera);
    }

    public void End() {
        Raylib.EndMode3D();
    }
}