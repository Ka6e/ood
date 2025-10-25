using Factory.Canvas;

namespace Factory.Factory.Shapes;
public abstract class Shape
{
    private Color _color;

    public Shape( Color color )
    {
        _color = color;
    }

    public Color GetColor() => _color;

    public abstract void Draw( ICanvas canvas );
}
