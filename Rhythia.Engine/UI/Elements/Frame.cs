using System.Numerics;
using Raylib_cs;

namespace Rhythia.Engine.UI.Elements;

public class Frame : UiElement {
    public Color Color = Color.White;

    public override void UpdateAbsoluteValues(Vector2 parentSize, Vector2 parentPosition) {
        base.UpdateAbsoluteValues(parentSize, parentPosition);
    }

    public override void Render() {
        Raylib.DrawRectanglePro(new Rectangle {
            X = AbsolutePosition.X,
            Y = AbsolutePosition.Y,
            Width = AbsoluteSize.X,
            Height = AbsoluteSize.Y,
        }, Vector2.Zero, 0f, Color);
        base.Render();
    }
}
