using CalculatorTestFramework.Configs;

namespace CalculatorTestFramework.Services;

public interface ITestConfigService
{
    TestSuiteConfig LoadFromFile(string filePath);
    List<TestSuiteConfig> LoadFromDirectory(string directoryPath);
}