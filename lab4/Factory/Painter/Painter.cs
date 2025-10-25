using Factory.Canvas;
using Factory.Designer;
using Factory.Factory.Shapes;

namespace Factory.Painter;
public class Painter : IPainter
{
    public void DrawPicture( PictureDraft draft, ICanvas canvas )
    {
        List<Shape> shapes = draft.GetShapes();

        foreach ( Shape shape in shapes )
        {
            shape.Draw( canvas );
        }
    }
}
