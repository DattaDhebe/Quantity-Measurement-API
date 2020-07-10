using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Model;
using CommanLayer.Models;
using RepositoryLayer.Interface;

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
                compare.Result = CompareConversion(compare);
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

        private string CompareConversion(Compare compare)
        {
            try
            {
                Compare comparison = new Compare();
                comparison.First_Value = compare.First_Value;
                comparison.First_Value_Unit = compare.First_Value_Unit;
                comparison.Second_Value = compare.Second_Value;
                comparison.Second_Value_Unit = compare.Second_Value_Unit;
                comparison = ConvertToBaseUnit(comparison);

                string result = "";

                if (comparison.First_Value_Unit == All_Enum.Unit.Inch.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Inch.ToString()
                    || comparison.First_Value_Unit == All_Enum.Unit.Gram.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Gram.ToString()
                    || comparison.First_Value_Unit == All_Enum.Unit.Mililiter.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Mililiter.ToString())
                {
                    if (comparison.First_Value == comparison.Second_Value)
                    {
                        result = "Equal";
                    }
                    else if (comparison.First_Value > comparison.Second_Value)
                    {
                        result = $"{compare.First_Value} Is Greater Than {compare.Second_Value}";
                    }
                    else if (comparison.First_Value < comparison.Second_Value)
                    {
                        result = $"{compare.First_Value} Is Less Than {compare.Second_Value}";
                    }
                }
                return result;
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
                double result = quantity.Result;

                // For Lenght Unit
                const double InchToFeetConstant = 12;
                const double InchToYardConstant = 36;
                const double FeetToYardConstant = 3;
                const double CentimeterToInchConstant = 2.5;

                // For Weight 
                const double WeightConstant = 1000;

                // For Volume
                const double VolumeConstant = 1000;
                const double GallonToLiterConstant = 3.78;
                //const double GallonToMililiterConstant = 3785.41;

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

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare ConvertToBaseUnit(Compare comparison)
        {
            try
            {
                //Checking If Data Is In Base Unit.
                if (comparison.First_Value_Unit == All_Enum.Unit.Inch.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Inch.ToString()
                    || comparison.First_Value_Unit == All_Enum.Unit.Gram.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Gram.ToString()
                    || comparison.First_Value_Unit == All_Enum.Unit.Mililiter.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Mililiter.ToString()
                    || comparison.First_Value_Unit == All_Enum.Unit.Farenheit.ToString() && comparison.Second_Value_Unit == All_Enum.Unit.Farenheit.ToString())
                {
                    return comparison;
                }

                //Creating QuantityModel Instances For Base Unit Conversions.
                Quantity quantityOne = new Quantity();
                Quantity quantityTwo = new Quantity();
                quantityOne.Value = comparison.First_Value;
                quantityTwo.Value = comparison.Second_Value;

                //Setting Operation Type.
                quantityOne.OptionType = SetOperationType(comparison.First_Value_Unit);
                quantityTwo.OptionType = SetOperationType(comparison.Second_Value_Unit);

                //If Both Quantity Instance Unit Are Not Base Units Then Perform Conversion.
                if (quantityOne.OptionType != "BaseUnit" && quantityTwo.OptionType != "BaseUnit")
                {
                    quantityOne.Result = Calculate(quantityOne);
                    quantityTwo.Result = Calculate(quantityTwo);

                    comparison.First_Value = quantityOne.Result;
                    comparison.Second_Value = quantityTwo.Result;

                    comparison.First_Value_Unit = SetBaseUnit(quantityOne);
                    comparison.Second_Value_Unit = SetBaseUnit(quantityTwo);
                }
                else if (quantityOne.OptionType == "BaseUnit" && quantityTwo.OptionType != "BaseUnit")
                {
                    quantityTwo.Result = Calculate(quantityTwo);
                    comparison.Second_Value = quantityTwo.Result;
                    comparison.Second_Value_Unit = SetBaseUnit(quantityTwo);
                }
                else if (quantityOne.OptionType != "BaseUnit" && quantityTwo.OptionType == "BaseUnit")
                {
                    quantityOne.Result = Calculate(quantityOne);
                    comparison.First_Value = quantityOne.Result;
                    comparison.First_Value_Unit = SetBaseUnit(quantityOne);
                }
                return comparison;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Functin Fr Setting peratin type For Base Unit Conversion.
        /// </summary>
        /// <param name="Unit_Value"></param>
        public string SetOperationType(string Unit_Value)
        {
            try
            {
                string operationType = Unit_Value;
                if (Unit_Value == All_Enum.Unit.Feet.ToString())
                {
                    operationType = "FeetToInch";
                }
                else if (Unit_Value == All_Enum.Unit.Yard.ToString())
                {
                    operationType = "YardToInch";
                }
                else if (Unit_Value == All_Enum.Unit.Centimeter.ToString())
                {
                    operationType = "CentimeterToInch";
                }
                else if (Unit_Value == All_Enum.Unit.Kilogram.ToString())
                {
                    operationType = "KilogramToGram";
                }
                else if (Unit_Value == All_Enum.Unit.Tonne.ToString())
                {
                    operationType = "TonneToGram";
                }
                else if (Unit_Value == All_Enum.Unit.Liter.ToString())
                {
                    operationType = "LiterToMililiter";
                }
                else if (Unit_Value == All_Enum.Unit.Gallon.ToString())
                {
                    operationType = "GallonToMililiter";
                }
                
                return operationType;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Function For Setting Base Unit.
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns>set the base unit</returns>
        public string SetBaseUnit(Quantity quantity)
        {
            try
            {
                if (quantity.OptionType == All_Enum.OptionType.FeetToInch.ToString()
                    || quantity.OptionType == All_Enum.OptionType.YardToInch.ToString() || quantity.OptionType == All_Enum.OptionType.CentimeterToInch.ToString())
                {
                    return "Inch";
                }
                else if (quantity.OptionType == All_Enum.OptionType.KilogramToGram.ToString() || quantity.OptionType == All_Enum.OptionType.TonneToGram.ToString())
                {
                    return "Gram";
                }
                else if (quantity.OptionType == All_Enum.OptionType.LiterToMililiter.ToString() || quantity.OptionType == All_Enum.OptionType.GallonToMililiter.ToString())
                {
                    return "Mililiter";
                }
                
                return "Invalid";
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    
    }
}
