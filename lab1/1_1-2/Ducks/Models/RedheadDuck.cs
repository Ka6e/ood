using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class RedheadDuck : Duck
{
    public RedheadDuck()
        : base( new FlyWithWings(), new QuackBehavior(), new Minuet() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm redhead duck!" );
    }
}
