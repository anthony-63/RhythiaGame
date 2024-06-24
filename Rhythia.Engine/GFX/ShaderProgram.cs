using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace Rhythia.Engine.GFX;

public class ShaderProgram
{
    public readonly int Handle;
    private readonly Dictionary<string, int> UniformLocations;

    public ShaderProgram(string vert, string frag)
    {
        var vertShader = GL.CreateShader(ShaderType.VertexShader);
        var fragShader = GL.CreateShader(ShaderType.FragmentShader);

        GL.ShaderSource(vertShader, vert);
        GL.ShaderSource(fragShader, frag);

        CompileShader(vertShader);
        CompileShader(fragShader);

        Handle = GL.CreateProgram();

        GL.AttachShader(Handle, vertShader);
        GL.AttachShader(Handle, fragShader);

        LinkProgram(Handle);

        GL.DetachShader(Handle, vertShader);
        GL.DetachShader(Handle, fragShader);

        GL.DeleteShader(fragShader);
        GL.DeleteShader(vertShader);

        GL.GetProgram(Handle, GetProgramParameterName.ActiveUniforms, out var uniformCount);

        UniformLocations = new Dictionary<string, int>();

        for(int i = 0; i < uniformCount; i++)
        {
            var key = GL.GetActiveUniform(Handle, i, out _, out _);
            var location = GL.GetUniformLocation(Handle, key);

            UniformLocations.Add(key, location);
        }
    }

    private static void CompileShader(int shader)
    {
        GL.CompileShader(shader);

        GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
        if(code != (int)All.True)
        {
            var infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Failed to compile shader({shader})\n\n{infoLog}");
        }
    }

    private static void LinkProgram(int program)
    {
        GL.LinkProgram(program);

        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
        if(code != (int)All.True)
        {
            var infoLog = GL.GetProgramInfoLog(program);
            throw new Exception($"Failed to link shader program({program})\n\n{infoLog}");
        }
    }

    public void Use()
    {
        GL.UseProgram(Handle);
    }

    public int GetAttributeLocation(string attributeName)
    {
        return GL.GetAttribLocation(Handle, attributeName);
    }

    public void SetInt(string name, int data)
    {
        GL.UseProgram(Handle);
        GL.Uniform1(UniformLocations[name], data);
    }

    public void SetFloat(string name, float data)
    {
        GL.UseProgram(Handle);
        GL.Uniform1(UniformLocations[name], data);
    }

    public void SetMatrix4(string name, Matrix4 data)
    {
        GL.UseProgram(Handle);
        GL.UniformMatrix4(UniformLocations[name], true, ref data);
    }

    public void SetVector3(string name, Vector3 data)
    {
        GL.UseProgram(Handle);
        GL.Uniform3(UniformLocations[name], data);
    }
}
