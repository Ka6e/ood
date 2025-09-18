using Ducks.Models;
using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;
using Moq;

namespace Ducks.Test;

[TestFixture]
public class DucksTests
{
    private Mock<IDanceBehavior> _danceMock;
    private Mock<IFlyBehavior> _flyMock;
    private Mock<IQuackBehavior> _quackMock;

    [SetUp]
    public void Setup()
    {
        _danceMock = new Mock<IDanceBehavior>();
        _flyMock = new Mock<IFlyBehavior>();
        _quackMock = new Mock<IQuackBehavior>();
    }

    [Test]
    public void Dance_DuckDance_WillDance()
    {
        var duck = new Mock<Duck>( _flyMock.Object, _quackMock.Object, _danceMock.Object ) { CallBase = true };

        duck.Object.Dance();

        _danceMock.Verify( d => d.Dance(), Times.Once );
    }

    [Test]
    public void Fly_DuckWithAnEvenFlights_DuckWillQuack()
    {
        _flyMock.Setup( f => f.FlightCount )
            .Returns( 2 );
        var duck = new Mock<Duck>( _flyMock.Object, _quackMock.Object, _danceMock.Object ) { CallBase = true };
        duck.Object.SetFlyBehavior( _flyMock.Object );

        duck.Object.Fly();

        _quackMock.Verify( q => q.Quack(), Times.Once );
    }

    [Test]
    public void Fly_DuckWithAnOddFlights_DuckWontQuack()
    {
        var duck = new Mock<Duck>( _flyMock.Object, _quackMock.Object, _danceMock.Object ) { CallBase = true };

        duck.Object.Fly();

        _quackMock.Verify(q => q.Quack(), Times.Never );
    }
}
