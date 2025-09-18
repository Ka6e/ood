using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class RedheadDuck : Duck
{
    public RedheadDuck()
        : base( FlyBehavior.FlyWithWings(), QuackBehavior.Quack(), DanceBehavior.Minuet() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm redhead duck!" );
    }
}
