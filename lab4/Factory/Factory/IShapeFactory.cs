using Factory.Factory.Shapes;

namespace Factory.Factory;
public interface IShapeFactory
{
    Shape CreateShape( string description );
}
