using Factory.Designer;
using Factory.Factory.Shapes;
using Moq;

namespace Factory.Tests;

[TestFixture]
public class PictureDraftTests
{

    [Test]
    public void GetShapeCount_Empty_ReturnZero()
    {
        PictureDraft draft = new PictureDraft();

        Assert.That( draft.GetShapeCount(), Is.EqualTo( 0 ) );
    }


    [Test]
    public void GetShapeAtIndex_InCorrectPosition_returnShape()
    {
        Color color = new( "#fff" );
        PictureDraft draft = new PictureDraft();
        Mock<Shape> mock = new( color );

        draft.AddShape( mock.Object );

        Assert.That( draft.GetShapeAtIndex( 0 ), Is.EqualTo( mock.Object ) );
    }

    [Test]
    public void GetShapeAtIndex_OutOfRange_Exception()
    {
        PictureDraft draft = new();

        Assert.Throws<ArgumentOutOfRangeException>( () => draft.GetShapeAtIndex( -1 ) );
    }

    [Test]
    public void GetShapes_TwoShapes_ReturnsTwo()
    {
        Color color = new( "#fff" );
        PictureDraft draft = new PictureDraft();
        Mock<Shape> mock1 = new( color );
        Mock<Shape> mock2 = new( color );

        draft.AddShape( mock1.Object );
        draft.AddShape( mock2.Object );

        Assert.That( draft.GetShapeCount(), Is.EqualTo( 2 ) );
    }
}
