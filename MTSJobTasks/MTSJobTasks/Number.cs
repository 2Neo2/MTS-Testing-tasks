namespace ConsoleApp6;

public class Number
{
    private readonly int _number;
    private IFormatProvider _ifp;

    public Number(int number, IFormatProvider ifp)
    {
        _number = number;
        _ifp = ifp;
    }

    public int GetNum()
    {
        return _number;
    }

    public override string ToString()
    {
        return _number.ToString(_ifp);
    }
}