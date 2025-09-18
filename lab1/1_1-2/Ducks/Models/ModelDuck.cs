using Ducks.Strategies.Dance;
using Ducks.Strategies.Fly;
using Ducks.Strategies.Quack;

namespace Ducks.Models;
public class ModelDuck : Duck
{
    public ModelDuck( ) 
        : base( new FlyNoWay(), new QuackBehavior(), new DanceNoWay() )
    {
    }

    public override void Display()
    {
        Console.WriteLine( "I'm model duck" );
    }
}
