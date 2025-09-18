namespace Ducks.Strategies.Fly;
public class FlyNoWay : IFlyBehavior
{
    public int FlightCount => 0;

    public void Fly() {}
}
