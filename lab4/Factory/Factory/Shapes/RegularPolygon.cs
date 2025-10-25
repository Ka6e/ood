using Factory.Canvas;

namespace Factory.Factory.Shapes;
public class RegularPolygon : Shape
{
    private readonly Point _center;
    private readonly double _radius;
    private readonly uint _vertexCount;
    public RegularPolygon(
        Color color,
        Point center,
        double radius,
        uint countVertex ) : base( color )
    {
        _center = center;
        _radius = radius;
        _vertexCount = countVertex;
    }

    public override void Draw( ICanvas canvas )
    {
        canvas.SetColor( GetColor() );

        double angleStep = 2 * Math.PI / _vertexCount;

        double startX = _center.X + _radius * Math.Cos( 0 );
        double startY = _center.Y + _radius * Math.Sin( 0 );

        double prevX = startX;
        double prevY = startY;

        for ( int i = 1; i <= _vertexCount; i++ )
        {
            double angle = i * angleStep; 
            double x = _center.X + _radius * Math.Cos( angle );
            double y = _center.Y + _radius * Math.Sin( angle );

            canvas.MoveTo( prevX, prevY );
            canvas.DrawLine( x, y );

            prevX = x;
            prevY = y;
        }

        canvas.MoveTo( prevX, prevY );
        canvas.DrawLine( startX, startY );
    }

    public Point GetCenter() => _center;

    public double GetRadius() => _radius;

    public uint GetVertexCount() => _vertexCount;
}
