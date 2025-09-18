using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class DecoyDuck : Duck
{
    public DecoyDuck()
        : base( FlyBehavior.FlyNoWay(), QuackBehavior.MuteQuack(), DanceBehavior.DanceNoWay() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm decoy duck" );
    }
}
