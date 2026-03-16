using System.Text.Json.Serialization;

namespace CalculatorTestFramework.Configs;

public record TestSuiteConfig
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("tests")]
    public List<TestCaseConfig> Tests { get; set; } = new();
}