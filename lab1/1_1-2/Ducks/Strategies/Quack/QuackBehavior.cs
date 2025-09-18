namespace Ducks.Strategies.Quack;
public class QuackBehavior : IQuackBehavior
{
    public void Quack()
    {
        Console.WriteLine( "Quack Quack!!!" );
    }
}
