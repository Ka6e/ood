using Ducks.Models;
using Moq;

namespace Ducks.Test;
public class DucksTests
{
    [Test]
    public void Dance_DuckDance_WillDance()
    {
        bool danced = false;
        Action danceMock = () => danced = true;
        var duck = new Mock<Duck>(
            () => 0,
            () => { },
            danceMock );

        duck.Object.Dance();

        Assert.That( danced, Is.True );
    }


    [Test]
    public void Fly_DuckWithAnEvenFlights_WillQuack()
    {
        int quackCount = 0;
        int flightCount = 0;
        Func<int> flyBehavior = () => ++flightCount;
        Action quackBehavior = () => ++quackCount;
        var duck = new Mock<Duck>(
            flyBehavior,
            quackBehavior,
            () => { } );

        duck.Object.Fly();

        Assert.That( quackCount, Is.EqualTo( 0 ) );
    }

    [Test]
    public void Fly_DuckWithAnOddFlights_WillNotQuack()
    {
        int quackCount = 0;
        int flightCount = 0;
        Func<int> flyBehavior = () => ++flightCount;
        Action quackBehavior = () => ++quackCount;
        var duck = new Mock<Duck>(
            flyBehavior,
            quackBehavior,
            () => { } );

        duck.Object.Fly();
        duck.Object.Fly();

        Assert.That(quackCount, Is.EqualTo ( 1 ) );
    }
}
