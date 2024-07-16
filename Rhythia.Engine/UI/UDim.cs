namespace Rhythia.Engine.UI;

public struct UDim {
    public float Scale { get; set; }
    public float Offset { get; set; }

    public static UDim Zero => new UDim(0, 0);

    public UDim(float scale, float offset) {
        Scale = scale;
        Offset = offset;
    }
}

public struct UDim2 {
    public UDim X { get; set; }
    public UDim Y { get; set; }

    public static UDim2 Zero => new UDim2(0, 0, 0, 0);

    public UDim2(UDim x, UDim y) {
        X = x;
        Y = y;
    }
    public UDim2(float xScale, float xOffset, float yScale, float yOffset) {
        X = new UDim(xScale, xOffset);
        Y = new UDim(yScale, yOffset);
    }
}