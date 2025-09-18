using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class MallardDuck : Duck
{
    public MallardDuck()
        : base( new FlyWithWings(), new QuackBehavior(), new Waltz() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm mallard duck" );
    }
}
