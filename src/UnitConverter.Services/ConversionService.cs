using UnitConverter.Core.Interfaces;
using UnitConverter.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace UnitConverter.Services;
public class ConversionService : IConversionService {
    private readonly IEnumerable<IUnitConverterStrategy> _strategies;
    public ConversionService(IEnumerable<IUnitConverterStrategy> strategies) { _strategies = strategies; }
    public ConversionResponse Convert(ConversionRequest request) {
        var strategy = _strategies.FirstOrDefault(s => s.CanConvert(request.FromUnit, request.ToUnit));
        if (strategy == null) throw new ArgumentException($"Conversion from {request.FromUnit} to {request.ToUnit} not supported.");
        return new ConversionResponse { OriginalValue = request.Value, FromUnit = request.FromUnit, ToUnit = request.ToUnit, ConvertedValue = Math.Round(strategy.Convert(request.Value, request.FromUnit, request.ToUnit), 4) };
    }
}
