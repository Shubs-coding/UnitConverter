namespace UnitConverter.Core.Models;
public class ConversionResponse {
    public decimal OriginalValue { get; set; }
    public string FromUnit { get; set; } = string.Empty;
    public decimal ConvertedValue { get; set; }
    public string ToUnit { get; set; } = string.Empty;
}
