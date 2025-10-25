using Factory.Canvas;
using Factory.Designer;

namespace Factory.Painter;
public interface IPainter
{
    void DrawPicture( PictureDraft draft, ICanvas canvas );
}
