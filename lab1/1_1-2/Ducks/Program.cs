using Ducks.Models;
using Ducks.Strategies.Fly;

namespace Ducks;

internal class Program
{
    static void Main( string[] args )
    {
        MallardDuck mallardDuck = new();
        Functions.PlayWithDuck( mallardDuck );

        RedheadDuck redheadDuck = new();
        Functions.PlayWithDuck( redheadDuck );

        RubberDuck rubberDuck = new();
        Functions.PlayWithDuck( rubberDuck );

        DecoyDuck decoyDuck = new();
        Functions.PlayWithDuck( decoyDuck );

        ModelDuck modelDuck = new();
        Functions.PlayWithDuck( modelDuck );

        modelDuck.SetFlyBehavior( new FlyWithWings() );
        Functions.PlayWithDuck( modelDuck );
    }
}
