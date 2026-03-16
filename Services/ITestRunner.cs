using CalculatorTestFramework.Configs;
using CalculatorTestFramework.Models;

namespace CalculatorTestFramework.Services;

public interface ITestRunner
{
    List<TestResult> RunAll(IEnumerable<TestSuiteConfig> suites);
}