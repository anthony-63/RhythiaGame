using System.Numerics;
using Raylib_cs;

namespace Rhythia.Engine.UI.Elements;

public class Frame : UiElement {
    public Color Color = Color.White;

    public Color BorderColor = Color.Gray;
    public float BorderWidth = 0f;

    public override void UpdateAbsoluteValues(Vector2 parentSize, Vector2 parentPosition) {
        base.UpdateAbsoluteValues(parentSize, parentPosition);
    }

    public override void Render() {
        if(BorderWidth > 0) {
            Raylib.DrawRectanglePro(new Rectangle {
                X = AbsolutePosition.X - BorderWidth,
                Y = AbsolutePosition.Y - BorderWidth,
                Width = AbsoluteSize.X + BorderWidth * 2,
                Height = AbsoluteSize.Y + BorderWidth * 2,
            }, Vector2.Zero, 0f, BorderColor);
        }

        Raylib.DrawRectanglePro(new Rectangle {
            X = AbsolutePosition.X,
            Y = AbsolutePosition.Y,
            Width = AbsoluteSize.X,
            Height = AbsoluteSize.Y,
        }, Vector2.Zero, 0f, Color);

        base.Render();
    }
}
