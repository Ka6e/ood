namespace Ducks.Strategies.Fly;
public static class FlyBehavior
{
    public static Func<int> FlyWithWings()
    {
        int flightCount = 0;

        Func<int> action = () =>
        {
            ++flightCount;
            Console.WriteLine( $"I'm flying with wings!! Flights {flightCount}" );

            return flightCount;
        };

        return action;

    }

    public static Func<int> FlyNoWay()
    {
        Func<int> action = () => { return 0; };

        return action;
    }
}
