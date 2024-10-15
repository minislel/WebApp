public class Calculator
{
    public Operator? op { get; set; }
    public double? A { get; set; }
    public double? B { get; set; }

    public String Op
    {
        get
        {
            switch (op)
            {
                case Operator.add:
                    return "+";                
                case Operator.sub: 
                    return "-";
                case Operator.mul:
                    return "*";
                case Operator.div:
                    return "÷";
                default:
                    return "";
            }
        }
    }

    public bool IsValid()
    {
        return op != null && A != null && B != null;
    }

    public double Calculate()
    {
        switch (op)
        {
            case Operator.add :
                return (double)(A + B);
            case Operator.sub :
                return (double)(A - B);
            case Operator.mul :
                return (double)(A * B);
            case Operator.div :
                return (double)(A / B);
            default: return double.NaN;
        }
    }
    public enum Operator
    {
        mul, div, add, sub
    }
}