struct Rectangle
{
    public double Length;

    public double Breadth;

    public double Area()
    {
        return Length * Breadth;
    }

    public override string ToString()
    {
        return $"{Length} x {Breadth}";
    }
}