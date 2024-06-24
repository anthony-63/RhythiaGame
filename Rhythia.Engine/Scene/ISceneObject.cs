namespace Rhythia.Engine.Scene;

interface ISceneObject {
    public void Update(Window window, double dt);
    public void Render(Window window);
}