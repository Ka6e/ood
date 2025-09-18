using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public abstract class Duck 
{
    private IFlyBehavior _flyBehavior;
    private IQuackBehavior _quackBehavior;
    private IDanceBehavior _danceBehavior;

    public Duck(
        IFlyBehavior flyBehavior,
        IQuackBehavior quackbehavior,
        IDanceBehavior danceBehavior )
    {
        SetFlyBehavior( flyBehavior );
        Validate( quackbehavior, danceBehavior );
    }

    public void Fly() => HandleFly();

    public void Quack() => _quackBehavior.Quack();

    public void Swim() => Console.WriteLine( "I'm swimming" );

    public void SetFlyBehavior( IFlyBehavior flyBehavior )
    {
        _flyBehavior = flyBehavior ?? throw new ArgumentNullException( nameof( flyBehavior ) );
    }

    public void Dance() => _danceBehavior.Dance();

    public abstract void Display();

    private void Validate( IQuackBehavior quackbehavior, IDanceBehavior danceBehavior )
    {
        _quackBehavior = quackbehavior;
        _danceBehavior = danceBehavior ?? throw new ArgumentNullException( nameof( danceBehavior ) );
    }

    private void HandleFly()
    {
        _flyBehavior.Fly();
     
        //добавить isCanFly
        if ( _flyBehavior.GetType() != typeof( FlyNoWay ) 
            && _flyBehavior.FlightCount % 2 == 0
            && _flyBehavior.FlightCount > 0)
        {
            Quack();
        }
    }
}
