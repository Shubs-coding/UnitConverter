namespace UnitConverter.Core.Interfaces;
public interface IUnitConverterStrategy {
    bool CanConvert(string fromUnit, string toUnit);
    decimal Convert(decimal value, string fromUnit, string toUnit);
}
