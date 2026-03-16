using System.Text.Json;
using CalculatorTestFramework.Configs;

namespace CalculatorTestFramework.Services;

public class TestConfigService : ITestConfigService
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        ReadCommentHandling = JsonCommentHandling.Skip,
        AllowTrailingCommas = true
    };

    public TestSuiteConfig LoadFromFile(string filePath)
    {
        var json = File.ReadAllText(filePath);
        var config = JsonSerializer.Deserialize<TestSuiteConfig>(json, JsonOptions)
            ?? throw new InvalidOperationException($"Failed to deserialize test config: {filePath}");
        return config;
    }

    public List<TestSuiteConfig> LoadFromDirectory(string directoryPath)
    {
        var list = new List<TestSuiteConfig>();
        if (!Directory.Exists(directoryPath))
            return list;

        foreach (var path in Directory.EnumerateFiles(directoryPath, "*.json"))
        {
            try
            {
                list.Add(LoadFromFile(path));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Skip {path}: {ex.Message}");
            }
        }

        return list;
    }
}