using UnitConverter.Core.Models;
namespace UnitConverter.Core.Interfaces;
public interface IConversionService {
    ConversionResponse Convert(ConversionRequest request);
}
