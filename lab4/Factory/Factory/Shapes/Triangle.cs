using Factory.Canvas;

namespace Factory.Factory.Shapes;
public class Triangle : Shape
{
    private Point _firstVerticle;
    private Point _secondVerticle;
    private Point _thirdVerticle;

    public Triangle( Color color, Point first, Point second, Point third ) : base( color )
    {
        _firstVerticle = first;
        _secondVerticle = second;
        _thirdVerticle = third;
    }

    public override void Draw( ICanvas canvas )
    {
        canvas.SetColor( GetColor() );
        canvas.MoveTo( _firstVerticle.X, _firstVerticle.Y );

        canvas.DrawLine( _secondVerticle.X, _secondVerticle.Y );
        canvas.DrawLine( _thirdVerticle.X, _thirdVerticle.Y );
        canvas.DrawLine( _firstVerticle.Y, _firstVerticle.X );
    }

    public Point GetFirstVerticle() => _firstVerticle;
    public Point GetSecondVerticle() => _secondVerticle;
    public Point GetThirdVerticle() => _thirdVerticle;
}
