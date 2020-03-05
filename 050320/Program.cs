using System;


namespace _050320
{
    class FunctionExplorer 
    {
        private readonly Func<double, double> _Func;
        public FunctionExplorer(Func<double, double> F) {
            _Func = F;
        }
        public double GetMinValue(double x1, double x2, double dx) {
            double min = double.PositiveInfinity;
            double x = x1;
            while (x <= x2) {
                double y = _Func(x);
                if (y < min) min = y;
                x += dx;
            }
            return min;
        }
        public double GetMinValue(double x1, double x2, double dx, out double xmin)
        {
            double min = double.PositiveInfinity;
            double x = x1;
            xmin = x;
            while (x <= x2)
            {
                double y = _Func(x);
                if (y < min) { min = y; xmin = x; }
                x += dx;
            }
            return min;
        }
        public FunctionValue GetMin(double x1, double x2, double dx) {
            double min = double.PositiveInfinity;
            double x = x1;
            var xmin = x;
            while (x <= x2) {
                double y = _Func(x);
                if (y < min) { min = y; xmin = x; }
                x += dx;
            } 
        return new FunctionValue(xmin, min);
        }
    }
struct FunctionValue {
public readonly double x;
public readonly double y;
public FunctionValue(double x, double y) {
        this.x = x;
        this.y = y;
}
}
    class Program {
    public static double FF(double x) { return x * x; }
    public static void Main(string[] args) {
        const double x0 = -5;
        const double y0 = -7;
        Func<double, double> f = x => (x - x0)*(x - x0) + y0;
            Func<double, double> ff = x => x * x;
        var explorer = new FunctionExplorer(f);

        var min_val = explorer.GetMin(-10, 10, 0.01);
        Console.WriteLine("minx={0}, miny={1}", min_val.x, min_val.y);
        var min = explorer.GetMinValue(-10, 10, 0.01);
        Console.WriteLine("min={0}", min);
            FunctionExplorer exp = new FunctionExplorer(FF);
    }
}
}


