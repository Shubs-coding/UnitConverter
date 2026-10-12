using UnitConverter.Core.Interfaces;
using System;
using System.Collections.Generic;
namespace UnitConverter.Services.Strategies;
public class LinearConverterStrategy : IUnitConverterStrategy {
    private readonly Dictionary<string, decimal> _rates = new(StringComparer.OrdinalIgnoreCase) {
        { "meter", 1m }, { "kilometer", 1000m }, { "centimeter", 0.01m }, { "mile", 1609.34m },
        { "gram", 1m }, { "kilogram", 1000m }, { "pound", 453.592m }
    };
    private readonly HashSet<string> _length = new(StringComparer.OrdinalIgnoreCase) { "meter", "kilometer", "centimeter", "mile" };
    private readonly HashSet<string> _mass = new(StringComparer.OrdinalIgnoreCase) { "gram", "kilogram", "pound" };
    public bool CanConvert(string fromUnit, string toUnit) => 
        (_length.Contains(fromUnit) && _length.Contains(toUnit)) || (_mass.Contains(fromUnit) && _mass.Contains(toUnit));
    public decimal Convert(decimal value, string fromUnit, string toUnit) => (value * _rates[fromUnit]) / _rates[toUnit];
}
