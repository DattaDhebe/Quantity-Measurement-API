using CommanLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IQuantityMeasurementRL
    {
        Quantity Add(Quantity quantity);
    }
}
