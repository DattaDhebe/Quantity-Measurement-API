using CommanLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface IQuantityMeasurementBL
    {
        Quantity Convert(Quantity info);
    }
}
