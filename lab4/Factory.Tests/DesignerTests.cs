using System.Text;
using Factory.Designer;
using Factory.Factory;
using Factory.Factory.Shapes;
using Moq;

namespace Factory.Tests;

[TestFixture]
public class DesignerTests
{
    private Designer.Designer _designer;
    private Mock<IShapeFactory> _factory;

    [SetUp]
    public void Setup()
    {
        _factory = new Mock<IShapeFactory>();
        _designer = new( _factory.Object );
    }

    [Test]
    public void CreateDraft_QuitCommand_ReturnEmptyDraft()
    {
        StreamReader stream = CreateStreamWithLines( "quit" );

        PictureDraft draft = _designer.CreateDraft( stream );

        Assert.That( draft.GetShapes().Count, Is.EqualTo( 0 ) );
    }

    [Test]
    public void CreateDraft_ExistShape_ReturnShape()
    {
        string input = "rectangle #B7B7B7 0 380 800 500";
        var stream = CreateStreamWithLines( input );

        var mockShape = new Mock<Shape>( new Color( "#B7B7B7" ) );

        var draft = _designer.CreateDraft( stream );

        Assert.That( draft.GetShapes().Count, Is.EqualTo( 1 ) );
    }

    private StreamReader CreateStreamWithLines( params string[] strings )
    {
        string text = string.Join( Environment.NewLine, strings );
        byte[] bytes = Encoding.UTF8.GetBytes( text );
        var memoryStream = new MemoryStream( bytes );
        return new StreamReader( memoryStream );
    }
}
