using Factory.Factory.Shapes;

namespace Factory.Designer;
public class PictureDraft
{
    private readonly List<Shape> _shapes = new();
    public int GetShapeCount() => _shapes.Count;

    public Shape GetShapeAtIndex( int index ) => _shapes[ index ];

    public List<Shape> GetShapes() => _shapes;

    public void AddShape( Shape shape ) => _shapes.Add( shape );
}
