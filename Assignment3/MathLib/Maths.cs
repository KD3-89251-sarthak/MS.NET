namespace MathLib
{
    public class Maths
    {
        public double Sum(int x, int y)
        {
            return x + y;
        }
        public double Sub(int x, int y)
        {
            return x - y;
        }
        public double Mul(int x, int y)
        {
            return (x * y);
        }
        public double Div(int x, int y)
        {
            if(y == 0)
            {
                throw new ArgumentException("Denumerator must be non-zero");
            }
            return x / y;
        }
    }
}
