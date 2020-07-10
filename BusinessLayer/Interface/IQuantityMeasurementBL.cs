using CommanLayer;
using CommanLayer.Models;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity Convert(Quantity info);

        Quantity GetQuantityById(int  Id);

        IEnumerable<Quantity> DeleteQuntityById(int Id);

        Compare AddComparedValue(Compare compare);

        IEnumerable<Compare> GetAllComparison();

        Compare GetComparisonById(int Id);

        IEnumerable<Compare> DeleteComparisonById(int Id);

    }
}
