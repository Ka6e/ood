namespace Ducks.Strategies.Quack;
public class SqueekBehavior : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine( "Squeek!!!" );
    }
}
