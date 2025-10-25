using Factory.Canvas;
using Factory.Factory.Shapes;
using Moq;

namespace Factory.Tests.ShapesTests;
public class ShapesTests
{
    private Mock<ICanvas> _canvasMock;

    [SetUp]
    public void SetUp()
    {
        _canvasMock = new Mock<ICanvas>();
    }

    [Test]
    public void Draw_WithСorrectCoordinate_DrawTriangle()
    {
        Point firstVerticle = new Point( 10, 20 );
        Point secondVerticle = new Point( 40, 20 );
        Point thirdVerticle = new Point( 25, 50 );

        var triangle = new Triangle(
                color: new Color( "#ffffff" ),
                firstVerticle,
                secondVerticle,
                thirdVerticle
            );

        triangle.Draw( _canvasMock.Object );

        _canvasMock.Verify( c => c.SetColor( It.Is<Color>( col => col.R == 255 && col.G == 255 && col.B == 255 ) ), Times.Once );

        _canvasMock.Verify( c => c.MoveTo( firstVerticle.X, firstVerticle.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( secondVerticle.X, secondVerticle.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( thirdVerticle.X, thirdVerticle.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( firstVerticle.X, firstVerticle.Y ), Times.Once );
    }

    [Test]
    public void Draw_WithCorrectCoordinate_DrawEllipse()
    {
        Point center = new Point( 50, 50 );
        double rx = 30;
        double ry = 20;

        var ellipse = new Ellipse( new Color( "#fff" ), center, ry, rx );

        ellipse.Draw( _canvasMock.Object );

        _canvasMock.Verify( c => c.SetColor( It.Is<Color>( col => col.R == 255 && col.G == 255 && col.B == 255 ) ), Times.Once );

        _canvasMock.Verify( c => c.DrawEllipse( center.X, center.Y, rx, ry ), Times.Once );
    }

    [Test]
    public void Draw_WithCorrectCoordinate_DrawRectangle()
    {
        Point leftTop = new Point( 10, 20 );
        Point rightBottom = new Point( 40, 10 );

        var rectangle = new Rectangle( new Color( "#fff" ), leftTop, rightBottom );

        rectangle.Draw( _canvasMock.Object );

        _canvasMock.Verify( c => c.SetColor( It.Is<Color>( col => col.R == 255 && col.G == 255 && col.B == 255 ) ), Times.Once );

        _canvasMock.Verify( c => c.MoveTo( 10, 20 ) );
        _canvasMock.Verify( c => c.DrawLine( rightBottom.X, leftTop.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( rightBottom.X, rightBottom.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( leftTop.X, rightBottom.Y ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( leftTop.X, leftTop.Y ), Times.Once );
    }

    [Test]
    public void Draw_WithCoorect_coordinate_DrawRegularPolygon()
    {
        var color = new Color( "#fff" );
        var center = new Point( 50, 50 );
        int pointsCount = 5;
        double radius = 30.0;

        var polygon = new RegularPolygon( color, center, radius, ( uint )pointsCount );


        polygon.Draw( _canvasMock.Object );

        _canvasMock.Verify( c => c.SetColor( It.Is<Color>( col => col.R == 255 && col.G == 255 && col.B == 255 ) ), Times.Once );

        double angleStep = 2 * Math.PI / pointsCount;
        double startX = center.X + radius * Math.Cos( 0 );
        double startY = center.Y + radius * Math.Sin( 0 );

        double prevX = startX;
        double prevY = startY;

        for ( int i = 1; i <= pointsCount; i++ )
        {
            double angle = i * angleStep;
            double x = center.X + radius * Math.Cos( angle );
            double y = center.Y + radius * Math.Sin( angle );

            _canvasMock.Verify( c => c.MoveTo( prevX, prevY ), Times.Once );
            _canvasMock.Verify( c => c.DrawLine( x, y ), Times.Once );

            prevX = x;
            prevY = y;
        }

        _canvasMock.Verify( c => c.MoveTo( prevX, prevY ), Times.Once );
        _canvasMock.Verify( c => c.DrawLine( startX, startY ), Times.Once );
    }
}

