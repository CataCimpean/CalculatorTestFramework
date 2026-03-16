namespace CalculatorTestFramework;

public class Calculator
{
    private List<string> _history = new List<string>();

    public int Add(params int[] numbers)
    {
        int result = 0;
        foreach (var number in numbers)
        {
            result += number;
        }
        AddToHistory("Add", numbers, result);
        return result;
    }

    public int Subtract(int a, int b)
    {
        int result = a - b;
        AddToHistory("Subtract", new[] { a, b }, result);
        return result;
    }

    public int Multiply(params int[] numbers)
    {
        int result = 1;
        foreach (var number in numbers)
        {
            result *= number;
        }
        AddToHistory("Multiply", numbers, result);
        return result;
    }

    public double Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero.");
        }
        double result = (double)a / b;
        AddToHistory("Divide", new[] { a, b }, result);
        return result;
    }

    public double Power(double baseNumber, double exponent)
    {
        double result = Math.Pow(baseNumber, exponent);
        AddToHistory("Power", new[] { (int)baseNumber, (int)exponent }, result);
        return result;
    }

    public double SquareRoot(double number)
    {
        if (number < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(number), "Cannot calculate square root of a negative number.");
        }
        double result = Math.Sqrt(number);
        AddToHistory("SquareRoot", new[] { (int)number }, result);
        return result;
    }

    public List<string> GetHistory()
    {
        return _history;
    }

    private void AddToHistory(string operation, int[] operands, double result)
    {
        _history.Add($"{operation}({string.Join(", ", operands)}) = {result}");
    }
}
