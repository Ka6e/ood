namespace Factory.Factory.Shapes;
public class Color
{
    public byte R { get; }
    public byte G { get; }
    public byte B { get; }

    public Color( string hex )
    {
        if ( String.IsNullOrWhiteSpace( hex ) )
        {
            throw new ArgumentNullException( "Color string cannot be empty" );
        }

        if ( hex.StartsWith( '#' ) )
        {
            hex = hex.Substring( 1 );
        }

        if ( hex.Length == 3 )
        {
            hex = DoubleHex( hex );
        }

        if ( hex.Length != 6 )
        {
            throw new ArgumentException( "Color must be in format #RRGGBB" );
        }

        R = Convert.ToByte( hex.Substring( 0, 2 ), 16 );
        G = Convert.ToByte( hex.Substring( 2, 2 ), 16 );
        B = Convert.ToByte( hex.Substring( 4, 2 ), 16 );
    }

    public override string ToString() => $"#{R:X2}{G:X2}{B:X2}";

    private string DoubleHex( string hex )
    {
        return string.Concat( hex[ 0 ], hex[ 0 ], hex[ 1 ], hex[ 1 ], hex[ 2 ], hex[ 2 ] );
    }
}
