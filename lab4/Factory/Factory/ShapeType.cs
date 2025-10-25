namespace Factory.Factory;
public enum ShapeType
{
    Unknown = 0,
    Ellipse = 1,
    Rectangle = 2,
    RegularPolygon = 3,
    Triangle = 4, 
}

public static class StringParser
{
    public static ShapeType StringToShapeType( string str )
    {
        switch ( str )
        {
            case "ellipse":
                return ShapeType.Ellipse;
            case "rectangle":
                return ShapeType.Rectangle;
            case "regular_polygon":
                return ShapeType.RegularPolygon;
            case "triangle":
                return ShapeType.Triangle;
            default:
                return ShapeType.Unknown;
        }
    }
}