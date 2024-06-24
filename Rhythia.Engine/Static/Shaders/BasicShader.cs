namespace Rhythia.Engine.Static.Shaders;

static class BasicShader {
    const string Vert = @"

#version 130

in vec3 vertexPosition;
in vec3 vertexColor;

out vec3 color;

uniform mat4 proj_mat;
uniform mat4 view_mat;
uniform mat4 model_mat;

void main(void)
{
    color = vertexColor;
    gl_Position = proj_mat * view_mat * model_mat * vec4(vertexPosition, 1);
}
";

    const string Frag = @"

#version 130

in vec3 color;
out vec4 fragment;

void main(void)
{
    fragment = vec4(color, 1);
}

    ";
}