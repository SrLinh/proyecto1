public class Square : Shape2
{
    public double SquareArea { get; set; }
    public double ShapeArea2( double Slide1, double Slide2)
    {
        SquareArea = Math.Round(Slide1*Slide2,2);
        return SquareArea;
    }
}