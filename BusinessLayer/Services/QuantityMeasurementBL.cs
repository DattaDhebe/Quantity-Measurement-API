using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Model;
using CommanLayer.Models;
using RepositoryLayer.Interface;
using static BusinessLayer.Length;

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
                //compare.Result = CompareConversion(compare);
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
    
        public double Calculate(Quantity quantity)
        {
            try
            {

                string operation = quantity.OptionType;
                double value = quantity.Value;
                //double result = quantity.Result;

                Length length = new Length();
                Weights weights = new Weights();
                Volumes volume = new Volumes();
                Temperature temperature = new Temperature();

                Unit unit = length.SetUnitAndConvertLength(operation);
                

                if (unit == Unit.FeetToInch || unit == Unit.YardToInch || unit == Unit.CentimeterToInch)
                {
                    return length.ConvertLength(unit, value);
                }

                return value;
               /* // For Lenght Unit
                const double InchToFeetConstant = 12;
                const double InchToYardConstant = 36;
                const double FeetToYardConstant = 3;
                const double CentimeterToInchConstant = 2.5;

                // For Weight 
                const double WeightConstant = 1000;

                // For Volume
                const double VolumeConstant = 1000;
                const double GallonToLiterConstant = 3.78;

                // For Temperature
            

                // For Lenght Unit
                if (operation == All_Enum.OptionType.InchToFeet.ToString())
                {
                    result = value / InchToFeetConstant;
                }
                else if (operation == All_Enum.OptionType.InchToYard.ToString())
                {
                    result = value / InchToYardConstant;
                }
                else if (operation == All_Enum.OptionType.FeetToInch.ToString())
                {
                    result = value * InchToFeetConstant;
                }
                else if (operation == All_Enum.OptionType.FeetToYard.ToString())
                {
                    result = value / FeetToYardConstant;
                }
                else if (operation == All_Enum.OptionType.YardToInch.ToString())
                {
                    result = value * InchToYardConstant;
                }
                else if (operation == All_Enum.OptionType.YardToFeet.ToString())
                {
                    result = value * FeetToYardConstant;
                }
                else if (operation == All_Enum.OptionType.CentimeterToInch.ToString())
                {
                    result = value / CentimeterToInchConstant;
                }

                // For Weight Units
                if (operation == All_Enum.OptionType.GramToKilogram.ToString() || operation == All_Enum.OptionType.KilogramToTonne.ToString())
                {
                    result = value / WeightConstant;
                }
                else if (operation == All_Enum.OptionType.GramToTonne.ToString())
                {
                    result = value / (WeightConstant * WeightConstant);
                }
                else if (operation == All_Enum.OptionType.KilogramToGram.ToString())
                {
                    result = value * WeightConstant;
                }
                else if (operation == All_Enum.OptionType.TonneToGram.ToString())
                {
                    result = value * (WeightConstant * WeightConstant);
                }

                //For Volume Units
                else if (operation == All_Enum.OptionType.MililiterToLiter.ToString())
                {
                    result = value / VolumeConstant;
                }
                else if (operation == All_Enum.OptionType.LiterToMililiter.ToString())
                {
                    result = value * VolumeConstant;
                }
                else if (operation == All_Enum.OptionType.LiterToGallon.ToString())
                {
                    result = value / GallonToLiterConstant;
                }
                else if (operation == All_Enum.OptionType.GallonToLiter.ToString())
                {
                    result = value * GallonToLiterConstant;
                }

                
                return Math.Round(result, 2);
               */
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }    
    }
}
