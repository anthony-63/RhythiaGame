using System.Numerics;

using Rhythia.Engine.UI.Elements;

namespace Rhythia.Engine.UI;

public class UiRoot {
    public List<IUiElement> Children = new();
    
    public void Render(int width, int height) {
        var parentSize = new Vector2(width, height);
        var parentPosition = Vector2.Zero;
        foreach (var element in Children) {
            element.UpdateAbsoluteValues(parentSize, parentPosition);
            element.Render();
        }
    }
    public void Update(double dt) {
        foreach (var element in Children) {
            element.Update(dt);
        }
    }
}