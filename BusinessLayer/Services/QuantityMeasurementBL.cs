using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Model;
using CommanLayer.Models;
using RepositoryLayer.Interface;
using static BusinessLayer.Length;
using static BusinessLayer.Weights;
using static BusinessLayer.Volumes;
using static BusinessLayer.Temperature;
using System.Security.Cryptography.X509Certificates;

namespace BusinessLayer.Services
{
    public class QuantityMeasurementBL : IQuantityMeasurementBL
    {
        private IQuantityMeasurementRL quantityMeasurementRL;

        public QuantityMeasurementBL(IQuantityMeasurementRL quantityMeasurementRL)
        {
            this.quantityMeasurementRL = quantityMeasurementRL;
        }

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return quantityMeasurementRL.GetAllQuantity();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity GetQuantityById(int Id)
        {
            try
            {
                return quantityMeasurementRL.GetQuantityById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return quantityMeasurementRL.GetAllComparison();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare GetComparisonById(int Id)
        {
            try
            {
                return quantityMeasurementRL.GetComparisonById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity Convert(Quantity quantity)
        {
            try
            {
                quantity.Result = UnitConversion(quantity);
                
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

        public IEnumerable<Quantity> DeleteQuntityById(int Id)
        {
            try
            {
                return quantityMeasurementRL.DeleteQuntityById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> DeleteComparisonById(int Id)
        {
            try
            {
                return quantityMeasurementRL.DeleteComparisonById(Id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare AddComparedValue(Compare compare)
        {
            try
            {
                compare.Result = UnitComparision(compare);
                if (compare.Result != null)
                {
                    return quantityMeasurementRL.AddComparedValue(compare);

                }
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double UnitConversion(Quantity quantity)
        {
            try
            {

                string MeasurementType = quantity.MeasurementType;
                string conversionType = quantity.ConversionType;
                double value = quantity.Value;
                return Conversion(MeasurementType, conversionType, value);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }           
        }

        private string UnitComparision(Compare compare)
        {
            try
            {
                string measurmentType = compare.MeasurementType;
                string firstValueUnit = compare.First_Value_Unit;
                double firstValue = compare.First_Value;
                string secondValueUnit = compare.Second_Value_Unit;
                double secondValue = compare.Second_Value;
                
                double firstResult =  this.Conversion(measurmentType, firstValueUnit, firstValue);
                double secondResult =  this.Conversion(measurmentType, secondValueUnit, secondValue);

                if (firstResult == secondResult)
                {
                    return "Equal";
                }

                if (firstResult >= secondResult)
                {
                    return firstValue + " is greater than " + secondValue;
                }

                if (firstResult <= secondResult)
                {
                    return firstValue + " is less than " + secondValue;
                }

                return null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private double Conversion(string MeasurementType, string conversionType, double value)
        {
            Length length = new Length();
            Weights weights = new Weights();
            Volumes volume = new Volumes();
            Temperature temperature = new Temperature();

            if (MeasurementType == "length")
            {
                LengthUnit unit = length.SetUnitAndConvertLength(conversionType);

                if (unit == LengthUnit.FeetToInch || unit == LengthUnit.YardToInch || unit == LengthUnit.CentimeterToInch)
                {
                    return length.ConvertLength(unit, value);
                }
            }

            if (MeasurementType == "weight")
            {
                WeightsUnit unit = weights.SetUnitAndConvertWeights(conversionType);
                if (unit.Equals(WeightsUnit.KilogramToGrams) || unit.Equals(WeightsUnit.TonneToKilograms))
                {
                    return weights.ConvertWeigths(unit, value);
                }
            }

            if (MeasurementType == "volume")
            {
                VolumeUnit unit = volume.SetUnitAndConvertVolume(conversionType);
                if (unit.Equals(VolumeUnit.GallonToLiter) || unit.Equals(VolumeUnit.LiterToMilliliter) || unit.Equals(VolumeUnit.MilliliterToLiter))
                {
                    return volume.ConvertVolumes(unit, value);
                }
            }
            if (MeasurementType == "temperature")
            {
                TemperatureUnit unit = temperature.SetUnitAndConvertTemperature(conversionType);
                if (unit.Equals(TemperatureUnit.CelsiusToFahrenheit))
                {
                    return temperature.ConvertTemperature(unit, value);
                }
            }

            return value;
        }
    }
}
