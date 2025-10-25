using Factory.Canvas;
using Factory.Designer;
using Factory.Factory;
using Factory.Painter;
using SFML.Graphics;
using SFML.Window;

//повторить паттерн фабрики
namespace Factory;
public class App
{
    private readonly RenderWindow _window;
    private readonly IDesigner _designer;
    private readonly IPainter _painter;
    private readonly Client _client;
    private readonly ICanvas _canvas;
    private readonly IShapeFactory _shapeFactory;

    public App()
    {
        _window = new RenderWindow( new VideoMode( 800, 600 ), "Shapes app" );
        _window.Closed += ( _, _ ) => _window.Close();

        _canvas = new Canvas.Canvas( _window );
        _shapeFactory = new ShapeFactory();
        _designer = new Designer.Designer( _shapeFactory );
        _painter = new Painter.Painter();
        _client = new( _designer );
    }

    public void Run()
    {
        while ( _window.IsOpen )
        {
            _window.DispatchEvents();
            _window.Clear( Color.White );

            ProcessInput();

            _window.Display();
        }
    }

    private void ProcessInput()
    {

        string path = "D:\\VS_Projects\\ood\\lab4\\Factory\\commands.txt";
        if ( !File.Exists( path ) )
        {
            Console.WriteLine( $"Файл '{path}' не найден!" );
            return;
        }
        using var reader = new StreamReader( path );

        _client.HandleCommand( reader, _canvas, _painter );

        if ( Keyboard.IsKeyPressed( Keyboard.Key.Escape ) )
        {
            _window.Close();
        }
    }
}

