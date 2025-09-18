namespace Ducks.Models;
public abstract class Duck
{
    private Func<int> _flyBehavior;
    private Action _quackBehavior;
    private Action _danceBehavior;

    public Duck(
        Func<int> flyBehavior,
        Action quackbehavior,
        Action danceBehavior )
    {
        SetFlyBehavior( flyBehavior );
        Validate( quackbehavior, danceBehavior );
    }

    public void Fly() => HandleFly();

    public void Quack() => _quackBehavior();

    public void Swim() => Console.WriteLine( "I'm swimming" );

    public void SetFlyBehavior( Func<int> flyBehavior )
    {
        _flyBehavior = flyBehavior ?? throw new ArgumentNullException( nameof( flyBehavior ) );
    }

    public void Dance() => _danceBehavior();

    public abstract void Display();

    private void Validate( Action quackbehavior, Action danceBehavior )
    {
        _quackBehavior = quackbehavior;
        _danceBehavior = danceBehavior;
    }

    private void HandleFly()
    {
        int flyCount = _flyBehavior();

        if ( flyCount % 2 == 0 && flyCount > 0 )
        {
            Quack();
        }
    }
}
