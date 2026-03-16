using CalculatorTestFramework.Configs;
using CalculatorTestFramework.Models;

namespace CalculatorTestFramework.Services;

public class TestRunnerService : ITestRunner
{
    public List<TestResult> RunAll(IEnumerable<TestSuiteConfig> suites)
    {
        var results = new List<TestResult>();
        var calc = new Calculator();

        foreach (var suite in suites)
        {
            foreach (var test in suite.Tests)
            {
                results.Add(RunOne(calc, suite.Name, test));
            }
        }

        return results;
    }

    static TestResult RunOne(Calculator calc, string suiteName, TestCaseConfig test)
    {
        var result = new TestResult
        {
            SuiteName = suiteName,
            TestName = test.Name,
            Method = test.Method,
            Arguments = string.Join(", ", test.Arguments),
            Expected = test.ExpectException != null ? $"Exception: {test.ExpectException}" : test.ExpectedResult?.ToString() ?? ""
        };

        try
        {
            var actual = Invoke(calc, test.Method, test.Arguments);

            if (test.ExpectException != null)
            {
                result.Passed = false;
                result.Actual = "No exception";
                result.ErrorMessage = $"Expected {test.ExpectException}.";
                return result;
            }

            result.Actual = actual?.ToString() ?? "";
            result.Passed = Match(test.ExpectedResult, actual);
            if (!result.Passed)
                result.ErrorMessage = $"Expected {test.ExpectedResult}, got {result.Actual}";
        }
        catch (Exception ex)
        {
            result.Actual = $"{ex.GetType().Name}: {ex.Message}";
            result.Passed = test.ExpectException != null &&
                string.Equals(ex.GetType().Name, test.ExpectException, StringComparison.OrdinalIgnoreCase);
            if (!result.Passed)
                result.ErrorMessage = ex.Message;
        }

        return result;
    }

    static bool Match(double? expected, object? actual)
    {
        if (expected == null) return actual == null;
        if (actual == null) return false;
        if (actual is int i) return i == (int)Math.Round(expected.Value);
        if (actual is double d) return Math.Round(d, 2) == Math.Round(expected.Value, 2);
        return false;
    }

    static object? Invoke(Calculator calc, string method, List<double> args)
    {
        return method switch
        {
            "Add" => calc.Add(args.ConvertAll(x => (int)x).ToArray()),
            "Subtract" => calc.Subtract((int)args[0], (int)args[1]),
            "Multiply" => calc.Multiply(args.ConvertAll(x => (int)x).ToArray()),
            "Divide" => calc.Divide((int)args[0], (int)args[1]),
            "Power" => calc.Power(args[0], args[1]),
            "SquareRoot" => calc.SquareRoot(args[0]),
            _ => throw new NotSupportedException($"Unknown method: {method}")
        };
    }
}