using UnitConverter.Core.Interfaces;
using System.Linq;
namespace UnitConverter.Services.Strategies;
public class TemperatureConverterStrategy : IUnitConverterStrategy {
    private readonly string[] _supportedUnits = { "celsius", "fahrenheit", "kelvin" };
    public bool CanConvert(string fromUnit, string toUnit) => _supportedUnits.Contains(fromUnit.ToLower()) && _supportedUnits.Contains(toUnit.ToLower());
    public decimal Convert(decimal value, string fromUnit, string toUnit) {
        fromUnit = fromUnit.ToLower(); toUnit = toUnit.ToLower();
        if (fromUnit == toUnit) return value;
        decimal celsius = fromUnit switch { "fahrenheit" => (value - 32m) * 5m / 9m, "kelvin" => value - 273.15m, _ => value };
        return toUnit switch { "fahrenheit" => (celsius * 9m / 5m) + 32m, "kelvin" => celsius + 273.15m, _ => celsius };
    }
}
