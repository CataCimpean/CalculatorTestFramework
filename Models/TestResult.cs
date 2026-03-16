namespace CalculatorTestFramework.Models;

public record TestResult
{
    public string SuiteName { get; set; } = string.Empty;
    public string TestName { get; set; } = string.Empty;
    public string Method { get; set; } = string.Empty;
    public string Arguments { get; set; } = string.Empty;
    public string Expected { get; set; } = string.Empty;
    public string Actual { get; set; } = string.Empty;
    public bool Passed { get; set; }
    public string? ErrorMessage { get; set; }
}