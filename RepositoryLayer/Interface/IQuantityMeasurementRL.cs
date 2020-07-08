using CommanLayer;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity Add(Quantity quantity);
    }
}
