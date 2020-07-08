using System;
using System.Collections.Generic;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Model;
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
                const double WeightConstant = 1000;

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

                // For Weight Unit
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

                return Math.Round(result, 2);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
