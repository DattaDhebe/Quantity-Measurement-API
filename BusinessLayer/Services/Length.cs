//-----------------------------------------------------------------------
// <copyright file="Length.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

using System.Data;

namespace BusinessLayer
{
    using System;

    /// <summary>
    /// Class for Feet Entity
    /// </summary>
    public class Length
    {
        const double InchToFeetConstant = 12.0;
        const double InchToYardConstant = 36.0;
        const double CentimeterToInchConstant = 2.5;

        /// <summary>
        /// Initializes a new instance of the <see cref="Length" /> class.
        /// </summary>
        public Length()
        {
        }



        /// <summary>
        /// enum to specify measurements
        /// </summary>
        public enum LengthUnit
        {
            /// <summary>
            /// Measurement for Feet
            /// </summary>
            Feet = 1,

            /// <summary>
            /// Measurement for Inch
            /// </summary>
            Inch,

            /// <summary>
            /// Measurement for Yard
            /// </summary>
            Yard,
           
            /// <summary>
            /// Measurement for Centimeter
            /// </summary>
            Centimeter,
          
            /// <summary>
            /// enum Indicating conversion from Feet To Inch
            /// </summary>
            FeetToInch,

            /// <summary>
            /// enum Indicating conversion from Yard To Inch
            /// </summary>
            YardToInch,

            /// <summary>
            /// enum Indicating conversion from Centimeter To Inch
            /// </summary>
            CentimeterToInch,
            
        }

        public LengthUnit SetUnitAndConvertLength(string operation)
        {
            if (operation == "FeetToInch")
            {
                return LengthUnit.FeetToInch;
            }

            if (operation == "YardToInch")
            {
                return LengthUnit.YardToInch;
            }
            
            if (operation == "CentimeterToInch")
            {
                return LengthUnit.CentimeterToInch;
            }

            return 0;
        }

        /// <summary>
        /// Method to convert one length to another
        /// </summary>
        /// <param name="unit">defines which unit used</param>
        /// <param name="length">length for conversion</param>
        /// <returns>returns value after calculation</returns>
        public double ConvertLength(LengthUnit unit, double length)
        {
            try
            {
                if (unit.Equals(LengthUnit.FeetToInch))
                {
                    return length * InchToFeetConstant;
                }

                if (unit.Equals(LengthUnit.YardToInch))
                {
                    return length * InchToYardConstant;
                }

                if (unit.Equals(LengthUnit.CentimeterToInch))
                {
                    return length / CentimeterToInchConstant;
                }
               
                return length;
            }
            catch (QuantityException e)
            {
                throw new QuantityException(QuantityException.ExceptionType.InvalidData, e.Message);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Method For Addition of Two Length
        /// </summary>
        /// <param name="firstValue">contains first length</param>
        /// <param name="secondValue">contains second length</param>
        /// <returns>return addition of Lengths</returns>
        public double CalculateLength(double firstValue, double secondValue)
        {
            try
            {
                // Addition of two values
                return firstValue + secondValue;
            }
            catch (QuantityException e)
            {
                throw new QuantityException(QuantityException.ExceptionType.InvalidData, e.Message);
            }
        }
    }
}
