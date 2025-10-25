using Factory.Canvas;
using Factory.Designer;
using Factory.Painter;

namespace Factory;
public class Client
{
    private readonly IDesigner _designer;
    public Client( IDesigner designer )
    {
        _designer = designer;
    }

    public void HandleCommand( StreamReader reader, ICanvas canvas, IPainter painter )
    {
        PictureDraft pictureDraft = _designer.CreateDraft( reader );

        painter.DrawPicture( pictureDraft, canvas );
    }
}
