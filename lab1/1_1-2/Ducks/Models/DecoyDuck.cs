using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class DecoyDuck : Duck
{
    public DecoyDuck()
        : base( new FlyNoWay(), new MuteQuackBehavior(), new DanceNoWay() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm decoy duck" );
    }
}
