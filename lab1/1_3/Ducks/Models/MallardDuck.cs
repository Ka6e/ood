using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class MallardDuck : Duck
{
    public MallardDuck()
        : base( FlyBehavior.FlyWithWings(), QuackBehavior.Quack(), DanceBehavior.Waltz() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm mallard duck" );
    }
}
