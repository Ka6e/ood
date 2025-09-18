using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class ModelDuck : Duck
{
    public ModelDuck()
        : base( FlyBehavior.FlyNoWay(), QuackBehavior.Quack(), DanceBehavior.DanceNoWay() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm model duck" );
    }
}
