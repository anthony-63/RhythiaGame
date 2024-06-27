using System.Numerics;

namespace Rhythia.Engine.UI.Elements;

public class UiElement : IUiElement
{
    private Vector2 absoluteSize = Vector2.Zero;
    private Vector2 absolutePosition = Vector2.Zero;

    public Vector2 AbsoluteSize => absoluteSize;
    public Vector2 AbsolutePosition => absolutePosition;

    public UDim2 Size = UDim2.Zero;
    public UDim2 Position = UDim2.Zero;

    public List<IUiElement> Children = new();

    public void Update(double dt)
    {
        foreach (var element in Children) element.Update(dt);
    }

    public void UpdateAbsoluteValues(Vector2 parentSize, Vector2 parentPosition) {
        absoluteSize = new Vector2(
            (parentSize.X * Size.X.Scale) + Size.X.Offset,
            (parentSize.Y * Size.Y.Scale) + Size.Y.Offset
        );
        absolutePosition = new Vector2(
            (parentSize.X * Position.X.Scale) + Position.X.Offset,
            (parentSize.Y * Position.Y.Scale) + Position.Y.Offset
        );
        foreach (var element in Children) {
            element.UpdateAbsoluteValues(absoluteSize, absolutePosition);
        }
    }

    public void Render()
    {
        foreach (var element in Children) element.Render();
    }
}