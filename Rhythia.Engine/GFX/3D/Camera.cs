using OpenTK.Mathematics;

namespace Rhythia.Engine.GFX._3D;

public class Camera
{
    
    public Vector3 Front = -Vector3.UnitZ;
    public Vector3 Up = Vector3.UnitY;
    public Vector3 Right = Vector3.UnitX;

    private float RealPitch;
    private float RealYaw = -MathHelper.PiOver2;
    private float RealFov = MathHelper.PiOver2;
    
    public Vector3 Position;
    public float AspectRatio { private get; set; }

    public float Pitch 
    {
        get => MathHelper.RadiansToDegrees(RealPitch);
        set
        {
            var angle = MathHelper.Clamp(value, -90, 90);
            RealPitch = MathHelper.DegreesToRadians(angle);
            UpdateVectors();
        }
    }

    public float Yaw 
    {
        get => MathHelper.RadiansToDegrees(RealYaw);
        set
        {
            RealYaw = MathHelper.DegreesToRadians(value);
            UpdateVectors();
        }
    }

    public float Fov
    {
        get => MathHelper.RadiansToDegrees(RealFov);
        set
        {
            var angle = MathHelper.Clamp(value, 1f, 90f);
            RealFov = MathHelper.DegreesToRadians(angle);
        }
    }

    public Camera(Vector3 position, float aspectRatio)
    {
        Position = position;
        AspectRatio = aspectRatio;
    }

    public Matrix4 GetViewMatrix()
    {
        return Matrix4.LookAt(Position, Position + Front, Up);
    }

    public Matrix4 GetProjectionMatrix()
    {
        return Matrix4.CreatePerspectiveFieldOfView(RealFov, AspectRatio, 0.01f, 100f);
    }

    private void UpdateVectors()
    {
        Front.X = MathF.Cos(RealPitch) * MathF.Cos(RealYaw);
        Front.Y = MathF.Sin(RealPitch);
        Front.Z = MathF.Cos(RealPitch) * MathF.Sin(RealYaw);

        Front = Vector3.Normalize(Front);

        Right = Vector3.Normalize(Vector3.Cross(Front, Vector3.UnitY));
        Up = Vector3.Normalize(Vector3.Cross(Right, Front));
    }
}