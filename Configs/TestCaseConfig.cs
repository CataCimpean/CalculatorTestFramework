using System.Text.Json.Serialization;

namespace CalculatorTestFramework.Configs;

public record TestCaseConfig
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("method")]
    public string Method { get; set; } = string.Empty;

    [JsonPropertyName("arguments")]
    public List<double> Arguments { get; set; } = new();

    [JsonPropertyName("expectedResult")]
    public double? ExpectedResult { get; set; }

    [JsonPropertyName("expectException")]
    public string? ExpectException { get; set; }
}