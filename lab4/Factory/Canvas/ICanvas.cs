using Factory.Factory.Shapes;

namespace Factory.Canvas;
public interface ICanvas
{
    void SetColor( Color color );
    void DrawLine( double x, double y );
    void DrawEllipse( double left, double top, double width, double height );
    void MoveTo( double x, double y );
}
