using Ducks.Models;

namespace Ducks;
public static class Functions
{
    public static void DrawDuck( Duck duck )
    {
        duck.Display();
    }

    public static void PlayWithDuck( Duck duck )
    {
        DrawDuck( duck );
        duck.Quack();
        duck.Fly();
        duck.Dance();
        Console.WriteLine();
    }
}
