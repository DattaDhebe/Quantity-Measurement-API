using CommanLayer;
using CommanLayer.Models;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity Add(Quantity quantity);

        IEnumerable<Quantity> DeleteQuntityById(int Id);

        Compare AddComparedValue(Compare compare);
    }
}
