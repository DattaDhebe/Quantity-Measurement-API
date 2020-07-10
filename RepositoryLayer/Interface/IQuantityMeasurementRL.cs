using CommanLayer;
using CommanLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity Add(Quantity quantity);

        Quantity GetQuantityById(int Id);

        IEnumerable<Quantity> DeleteQuntityById(int Id);

        Compare AddComparedValue(Compare compare);

        IEnumerable<Compare> GetAllComparison();

        Compare GetComparisonById(int Id);

        IEnumerable<Compare> DeleteComparisonById(int Id);
    }
}
