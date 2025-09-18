using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class RubberDuck : Duck
{
    public RubberDuck()
        : base( FlyBehavior.FlyNoWay(), QuackBehavior.Squeek(), DanceBehavior.DanceNoWay() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm rubber duck" );
    }
}
