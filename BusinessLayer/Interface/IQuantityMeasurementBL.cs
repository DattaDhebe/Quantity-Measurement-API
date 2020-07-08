using CommanLayer;
using System.Collections.Generic;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBL
    {
        IEnumerable<Quantity> GetAllQuantity();

        Quantity Convert(Quantity info);

    }
}
