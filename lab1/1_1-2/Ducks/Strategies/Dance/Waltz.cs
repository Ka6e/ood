namespace Ducks.Strategies.Dance;
public class Waltz : IDanceBehavior
{
    public void Dance()
    {
        Console.WriteLine( "I'm waltzing." );
    }
}
