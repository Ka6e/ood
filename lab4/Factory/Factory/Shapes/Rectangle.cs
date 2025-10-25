using Factory.Canvas;

namespace Factory.Factory.Shapes;
public class Rectangle : Shape
{
    private readonly Point _topLeft;
    private readonly Point _bottomRight;

    public Rectangle( Color color, Point topLeft, Point bottomRight ) : base( color )
    {
        _topLeft = topLeft;
        _bottomRight = bottomRight;
    }

    public override void Draw( ICanvas canvas )
    {
        canvas.SetColor( GetColor() );

        canvas.MoveTo( _topLeft.X, _topLeft.Y );
        canvas.DrawLine( _bottomRight.X, _topLeft.Y );
        canvas.DrawLine( _bottomRight.X, _bottomRight.Y );
        canvas.DrawLine( _topLeft.X, _bottomRight.Y );
        canvas.DrawLine( _topLeft.X, _topLeft.Y );
    }

    public Point GetTopLeft() => _topLeft;
    public Point GetBottomRight() => _bottomRight;
    public double GetWidth() => Math.Abs( _bottomRight.X - _topLeft.X );
    public double GetHeight() => Math.Abs( _bottomRight.Y - _topLeft.Y );
}
