using Factory.Factory.Shapes;

namespace Factory.Factory;
public class ShapeFactory : IShapeFactory
{
    public Shape CreateShape( string description )
    {
        if ( string.IsNullOrWhiteSpace( description ) )
        {
            throw new ArgumentNullException( "String cannot be empty" );
        }

        string[] parametrs = description.Split( new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries );
        ShapeType type = ParseStringToShapeType( parametrs[ 0 ] );

        return type switch
        {
            ShapeType.Ellipse => CreateEllipse( parametrs ),
            ShapeType.Rectangle => CreateRectangle( parametrs ),
            ShapeType.RegularPolygon => CreateRegularPolygon( parametrs ),
            ShapeType.Triangle => CreateTriangle( parametrs ),
            ShapeType.Unknown => throw new ArgumentException( "Unkown shape type" ),
        };

    }

    private ShapeType ParseStringToShapeType( string str )
    {
        return StringParser.StringToShapeType( str );
    }

    private Shape CreateEllipse( params string[] parametrs )
    {
        if ( parametrs.Length != 6 )
        {
            throw new ArgumentException( $"Parametrs for ellipse must be 6" );
        }

        Color color = new( parametrs[ 1 ] );
        double x = double.Parse( parametrs[ 2 ] );
        double y = double.Parse( parametrs[ 3 ] );
        double rx = double.Parse( parametrs[ 4 ] );
        double ry = double.Parse( parametrs[ 5 ] );

        return new Ellipse( color, new Point( x, y ), rx, ry );
    }

    private Shape CreateRectangle( params string[] parametrs )
    {
        if ( parametrs.Length != 6 )
        {
            throw new ArgumentException( $"Parametrs for rectangle must be 6" );
        }

        Color color = new( parametrs[ 1 ] );
        double x1 = double.Parse( parametrs[ 2 ] );
        double y1 = double.Parse( parametrs[ 3 ] );
        double x2 = double.Parse( parametrs[ 4 ] );
        double y2 = double.Parse( parametrs[ 5 ] );

        return new Rectangle( color, new Point( x1, y1 ), new Point( x2, y2 ) );
    }

    private Shape CreateTriangle( params string[] parametrs )
    {
        if ( parametrs.Length != 8 )
        {
            throw new ArgumentException( $"Parametrs for triangle must be 8" );

        }

        Color color = new( parametrs[ 1 ] );
        double x1 = double.Parse( parametrs[ 2 ] );
        double y1 = double.Parse( parametrs[ 3 ] );
        double x2 = double.Parse( parametrs[ 4 ] );
        double y2 = double.Parse( parametrs[ 5 ] );
        double x3 = double.Parse( parametrs[ 6 ] );
        double y3 = double.Parse( parametrs[ 7 ] );

        return new Triangle( color, new Point( x1, y1 ), new Point( x2, y2 ), new Point( x3, y3 ) );
    }

    private Shape CreateRegularPolygon( params string[] parametrs )
    {
        if ( parametrs.Length != 6 )
        {
            throw new ArgumentException( $"Parametrs for rugular polygon must be 5" );
        }

        Color color = new( parametrs[ 1 ] );
        double x = double.Parse( parametrs[ 2 ] );
        double y = double.Parse( parametrs[ 3 ] );
        double radius = double.Parse( parametrs[ 4 ] );
        uint verticlesCount = uint.Parse( parametrs[ 5 ] );

        return new RegularPolygon( color, new Point( x, y ), radius, verticlesCount );
    }
}
