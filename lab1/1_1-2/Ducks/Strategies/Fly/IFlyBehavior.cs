namespace Ducks.Strategies.Fly;
public interface IFlyBehavior
{
    int FlightCount { get; }

    void Fly();
}
