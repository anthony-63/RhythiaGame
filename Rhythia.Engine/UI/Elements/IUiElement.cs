using System.Numerics;

namespace Rhythia.Engine.UI.Elements;

public interface IUiElement {
    public Vector2 AbsoluteSize { get; }
    public Vector2 AbsolutePosition { get; }
    public void Update(double dt);
    public void UpdateAbsoluteValues(Vector2 parentSize, Vector2 parentPosition);
    public void Render();
}