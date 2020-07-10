using CommanLayer;
using CommanLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity GetQuantityById(int Id);

        Quantity Add(Quantity quantity);


        IEnumerable<Quantity> DeleteQuntityById(int Id);

        IEnumerable<Compare> GetAllComparison();

        Compare GetComparisonById(int Id);

        Compare AddComparedValue(Compare compare);

        IEnumerable<Compare> DeleteComparisonById(int Id);
    }
}
