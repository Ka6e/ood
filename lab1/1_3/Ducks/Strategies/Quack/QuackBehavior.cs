namespace Ducks.Strategies.Quack;
public static class QuackBehavior
{
    public static Action Quack()
    {
        return () => Console.WriteLine( "Quack Quack!!!" );
    }

    public static Action Squeek()
    {
        return () => Console.WriteLine( "Squeek!!!" );
    }

    public static Action MuteQuack()
    {
        return () => { };
    }
}
