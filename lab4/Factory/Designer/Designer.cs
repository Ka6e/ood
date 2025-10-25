using Factory.Factory;
using Factory.Factory.Shapes;

namespace Factory.Designer;
public class Designer : IDesigner
{
    private IShapeFactory _factory;

    public Designer( IShapeFactory shapeFactory )
    {
        _factory = shapeFactory;
    }

    public PictureDraft CreateDraft( StreamReader stream )
    {
        PictureDraft pictureDraft = new();
        string line;
        while ( ( line = stream.ReadLine() ) != null )
        {
            if ( line == "quit" )
            {
                break;
            }

            Shape shape = _factory.CreateShape( line );
            pictureDraft.AddShape( shape );
        }

        return pictureDraft;
    }
}
