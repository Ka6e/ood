using Factory.Canvas;
using Factory.Designer;
using Factory.Factory.Shapes;
using Moq;

namespace Factory.Tests;

[TestFixture]
public class PainterTests
{

    private Mock<ICanvas> _mockCanvas;
    private PictureDraft _pictureDraft;
    private Painter.Painter _painter;

    [SetUp]
    public void Setup()
    {
        _mockCanvas = new Mock<ICanvas>();
        _pictureDraft = new PictureDraft();
        _painter = new();
    }

    [Test]
    public void DrawPicture_NoShapes_ShouldNotDraw()
    {
        _painter.DrawPicture( _pictureDraft, _mockCanvas.Object );

        _mockCanvas.VerifyNoOtherCalls();
    }

    [Test]
    public void DrawPicture_DraftHasShapes_ShouldDrawAllShapes()
    {
        var color = new Color( "#ffffff" );
        var mockShape1 = new Mock<Shape>( color );
        var mockShape2 = new Mock<Shape>( color );

        _pictureDraft.AddShape( mockShape1.Object );
        _pictureDraft.AddShape( mockShape2.Object );

        _painter.DrawPicture( _pictureDraft, _mockCanvas.Object );

        mockShape1.Verify( s => s.Draw( _mockCanvas.Object ), Times.Once() );
        mockShape2.Verify( s => s.Draw( _mockCanvas.Object ), Times.Once() );
    }

    [Test]
    public void DrawPicture_DraftHasShapes_ShouldDrawInCorrectOrder()
    {
        var color = new Color( "#ffffff" );
        var mockShape1 = new Mock<Shape>( color );
        var mockShape2 = new Mock<Shape>( color );
        var mockShape3 = new Mock<Shape>( color );

        _pictureDraft.AddShape( mockShape1.Object );
        _pictureDraft.AddShape( mockShape2.Object );
        _pictureDraft.AddShape( mockShape3.Object );

        _painter.DrawPicture( _pictureDraft, _mockCanvas.Object );

        Assert.That( _pictureDraft.GetShapes().Count, Is.EqualTo( 3 ) );
        Assert.That( _pictureDraft.GetShapeAtIndex( 0 ), Is.EqualTo( mockShape1.Object ) );
        Assert.That( _pictureDraft.GetShapeAtIndex( 1 ), Is.EqualTo( mockShape2.Object ) );
        Assert.That( _pictureDraft.GetShapeAtIndex( 2 ), Is.EqualTo( mockShape3.Object ) );
    }
}
