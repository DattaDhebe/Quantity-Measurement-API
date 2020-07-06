using BusinessLayer.Interface;
using CommanLayer.Model;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementBL
    {
        IQuantityMeasurementRL quantityMeasurementRL;

        public QuantityMeasurementBL(IQuantityMeasurementRL quantityMeasurementRL)
        {
            this.quantityMeasurementRL = quantityMeasurementRL;
        }

        public Quantity Convert(Quantity quantity)
        {
            try
            {
                quantity.Result = Calculate(quantity);
                if(quantity.Result > 0)
                {
                    return quantityMeasurementRL.Add(quantity);
                }

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public double Calculate(Quantity quantity)
        {
            try
            {
                double value = quantity.Value;
                double result = quantity.Result;
                const double InchToFeet = 12;

                return value * InchToFeet;
                
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
