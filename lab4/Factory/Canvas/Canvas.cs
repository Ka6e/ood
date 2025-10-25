using SFML.Graphics;
using SFML.System;

namespace Factory.Canvas;
public class Canvas : ICanvas
{
    private readonly RenderWindow _window;
    private Vector2f _position;
    private Color _color = Color.White;

    public Canvas( RenderWindow window )
    {
        _window = window;
    }

    public void DrawEllipse( double left, double top, double width, double height )
    {
        var ellipse = new CircleShape( ( float )width, 100 );

        ellipse.Scale = new Vector2f( 1.0f, ( float )( height / width ) );
        ellipse.FillColor = _color;
        ellipse.OutlineColor = _color;
        ellipse.OutlineThickness = 2;
        ellipse.Position = new Vector2f( ( float )( left - width ), ( float )( top - height ) );

        _window.Draw( ellipse );
    }

    public void DrawLine( double x, double y )
    {
        var line = new VertexArray( PrimitiveType.Lines, 2 );
        line[ 0 ] = new Vertex( new Vector2f( _position.X, _position.Y ), _color );
        line[ 1 ] = new Vertex( new Vector2f( ( float )x, ( float )y ) );

        _window.Draw( line );

        _position = new Vector2f( ( float )x, ( float )y );
    }

    public void SetColor( Factory.Shapes.Color color )
    {
        _color = new Color( color.R, color.G, color.B );
    }

    public void MoveTo( double x, double y )
    {
        _position = new Vector2f( ( float )x, ( float )y );
    }
}
