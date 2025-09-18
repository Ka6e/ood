namespace Ducks.Strategies.Fly;
public class FlyWithWings : IFlyBehavior
{
    private int _flightCount = 0;
    public int FlightCount => _flightCount;

    public void Fly()
    {
        ++_flightCount;
        Console.WriteLine( $"I'm flying with wings!!. Flights {FlightCount}" );
    }
}
