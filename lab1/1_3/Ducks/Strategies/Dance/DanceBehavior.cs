namespace Ducks.Strategies.Dance;
public static class DanceBehavior
{
    public static Action Minuet()
    {
        return () => Console.WriteLine( "I'm dancing a minuet." );
    }

    public static Action Waltz()
    {
        return () => Console.WriteLine( "I'm waltzing." );
    }

    public static Action DanceNoWay()
    {
        return () => { };
    }
}
