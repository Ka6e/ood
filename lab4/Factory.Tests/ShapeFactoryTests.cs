using Factory.Factory;
using Factory.Factory.Shapes;

namespace Factory.Tests;

[TestFixture]
public class ShapeFactoryTests
{
    private ShapeFactory _factory = new();


    [Test]
    public void CreateShape_EllipseParametrs_WillCreatedEllipse()
    {
        string ellipse = "ellipse #ffffff 10 20 5 8";

        Shape shape = _factory.CreateShape( ellipse );
        Ellipse ellipseShape = ( Ellipse )shape;

        Assert.That( shape, Is.InstanceOf<Ellipse>() );
        Assert.That( ellipseShape.GetColor().R, Is.EqualTo( 255 ) );
        Assert.That( ellipseShape.GetColor().G, Is.EqualTo( 255 ) );
        Assert.That( ellipseShape.GetColor().B, Is.EqualTo( 255 ) );
        Assert.That( ellipseShape.GetHorizontalRadius(), Is.EqualTo( 8 ) );
        Assert.That( ellipseShape.GetVerticalRadius(), Is.EqualTo( 5 ) );
    }

    [Test]
    public void CreateShape_TriangleParametrs_WillCreatedTriangle()
    {
        string triangle = "triangle #ffffff 0 0 2 2 4 0";

        Shape shape = _factory.CreateShape( triangle );
        Triangle triangleShape = ( Triangle )shape;

        var p1 = triangleShape.GetFirstVerticle();
        var p2 = triangleShape.GetSecondVerticle();
        var p3 = triangleShape.GetThirdVerticle();


        Assert.That( shape, Is.InstanceOf<Triangle>() );
        Assert.That( triangleShape.GetColor().R, Is.EqualTo( 255 ) );
        Assert.That( triangleShape.GetColor().G, Is.EqualTo( 255 ) );
        Assert.That( triangleShape.GetColor().B, Is.EqualTo( 255 ) );
        Assert.That( p1.X, Is.EqualTo( 0 ) );
        Assert.That( p1.Y, Is.EqualTo( 0 ) );
        Assert.That( p2.X, Is.EqualTo( 2 ) );
        Assert.That( p2.Y, Is.EqualTo( 2 ) );
        Assert.That( p3.X, Is.EqualTo( 4 ) );
        Assert.That( p3.Y, Is.EqualTo( 0 ) );
    }

    [Test]
    public void CreateShape_RectangleParametrs_WillCreatedRectangle()
    {
        string rectangle = "rectangle #ffffff 0 10 20 0";

        Shape shape = _factory.CreateShape( rectangle );
        Rectangle rectangleShape = ( Rectangle )shape;

        var p1 = rectangleShape.GetTopLeft();
        var p2 = rectangleShape.GetBottomRight();

        Assert.That( shape, Is.InstanceOf<Rectangle>() );
        Assert.That( p1.X, Is.EqualTo( 0 ) );
        Assert.That( p1.Y, Is.EqualTo( 10 ) );
        Assert.That( p2.X, Is.EqualTo( 20 ) );
        Assert.That( p2.Y, Is.EqualTo( 0 ) );
        Assert.That( rectangleShape.GetColor().R, Is.EqualTo( 255 ) );
        Assert.That( rectangleShape.GetColor().G, Is.EqualTo( 255 ) );
        Assert.That( rectangleShape.GetColor().B, Is.EqualTo( 255 ) );
        Assert.That( rectangleShape.GetWidth(), Is.EqualTo( 20 ) );
        Assert.That( rectangleShape.GetHeight(), Is.EqualTo( 10 ) );
    }

    [Test]
    public void CreateShape_RegularPolygon_WillCreatedRegularPolygon()
    {
        string reg = "regular_polygon #ffffff 10 10 5 6";

        Shape shape = _factory.CreateShape( reg );
        RegularPolygon polygon = ( RegularPolygon )shape;

        var p = polygon.GetCenter();

        Assert.That( shape, Is.InstanceOf<RegularPolygon>() );
        Assert.That( polygon.GetVertexCount(), Is.EqualTo( 6 ) );
        Assert.That( polygon.GetRadius(), Is.EqualTo( 5 ) );
        Assert.That( polygon.GetColor().R, Is.EqualTo( 255 ) );
        Assert.That( polygon.GetColor().G, Is.EqualTo( 255 ) );
        Assert.That( polygon.GetColor().B, Is.EqualTo( 255 ) );
        Assert.That( p.X, Is.EqualTo( 10 ) );
        Assert.That( p.Y, Is.EqualTo( 10 ) );
    }

    [Test]
    public void CreateShape_EmptyString_Exception()
    {
        string empty = string.Empty;

        Assert.Throws<ArgumentNullException>( () => _factory.CreateShape( empty ) );
    }

    [Test]
    public void CreateShape_UnknownShapeTy_Exception()
    {
        string unknown = "un #ffffff 10 10 5 6";

        Assert.Throws<ArgumentException>( () => _factory.CreateShape( unknown ) );
    }

    [TestCase( "ellipse #ffffff 10 5 8" )]
    [TestCase( "rectangle #ffffff 0 10 20" )]
    [TestCase( "regular_polygon 10 10 5 6" )]
    [TestCase( "triangle #ffffff 0 2 2 4 0" )]
    public void CreateShape_InvalidArgumentLenght_Exception( string desc )
    {
        Assert.Throws<ArgumentException>( () => _factory.CreateShape( desc ) );
    }

    [TestCase( "ellipse #fffff 10 20 5 8" )]
    [TestCase( "ellipse #fffffff 10 20 5 8" )]
    [TestCase( "ellipse #ffff 10 20 5 8" )]
    [TestCase( "ellipse #ff 10 20 5 8" )]
    [TestCase( "ellipse #f 10 20 5 8" )]
    public void CreateShape_InvalidColor_Exception( string desc )
    {
        Assert.Throws<ArgumentException>( () => _factory.CreateShape( desc ) );
    }
}