namespace UnitConverter.Core.Models;
public class ConversionRequest {
    public decimal Value { get; set; }
    public string FromUnit { get; set; } = string.Empty;
    public string ToUnit { get; set; } = string.Empty;
}
