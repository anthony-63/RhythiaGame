using System.Numerics;
using Raylib_cs;

namespace Rhythia.Engine.UI.Elements;

public class Label : UiElement {
    public string Text = "Lorem ipsum";

    public Color TextColor = Color.White;

    public Font Font = Raylib.GetFontDefault();
    public int FontSize = 18;
    public int FontSpacing = 1;

    public TextAlignX AlignmentX = TextAlignX.Center;
    public TextAlignY AlignmentY = TextAlignY.Middle;
    // TODO: text wrapping

    private Vector2 absoluteTextSize = Vector2.Zero;
    public Vector2 AbsoluteTextSize => absoluteTextSize;

    public override void UpdateAbsoluteValues(Vector2 parentSize, Vector2 parentPosition)
    {
        absoluteTextSize = Raylib.MeasureTextEx(Font, Text, FontSize, FontSpacing);
        base.UpdateAbsoluteValues(parentSize, parentPosition);
    }

    public override void Render()
    {
        var textPosition = Vector2.Zero;
        if (AlignmentX == TextAlignX.Center) textPosition.X = (AbsoluteSize.X - absoluteTextSize.X) / 2;
        if (AlignmentX == TextAlignX.Right) textPosition.X = AbsoluteSize.X - absoluteTextSize.X;
        if (AlignmentY == TextAlignY.Middle) textPosition.Y = (AbsoluteSize.Y - absoluteTextSize.Y) / 2;
        if (AlignmentY == TextAlignY.Bottom) textPosition.Y = AbsoluteSize.Y - absoluteTextSize.Y;
        Raylib.DrawTextEx(Font, Text, textPosition, FontSize, FontSpacing, TextColor);
        base.Render();
    }
}

public enum TextAlignX {
    Left,
    Center,
    Right
}
public enum TextAlignY {
    Top,
    Middle,
    Bottom
}