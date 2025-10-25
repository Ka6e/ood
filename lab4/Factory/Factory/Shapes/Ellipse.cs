using Factory.Canvas;

namespace Factory.Factory.Shapes;
public class Ellipse : Shape
{
    private Point _center;
    private double _verticalRadius;
    private double _horizontalRadius;

    public Ellipse( Color color, Point center, double verticalRadius, double horizontalRadius ) : base( color )
    {
        _center = center;
        _verticalRadius = verticalRadius;
        _horizontalRadius = horizontalRadius;
    }

    public override void Draw( ICanvas canvas )
    {
        canvas.SetColor( GetColor() );
        canvas.DrawEllipse( _center.X, _center.Y, _horizontalRadius, _verticalRadius );
    }

    public Point GetCenter() => _center;

    public double GetVerticalRadius() => _verticalRadius;

    public double GetHorizontalRadius() => _horizontalRadius;
}
