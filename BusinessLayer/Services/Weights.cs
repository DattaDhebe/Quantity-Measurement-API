//-----------------------------------------------------------------------
// <copyright file="Weights.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;

    /// <summary>
    /// class for weights
    /// </summary>
    public class Weights
    {        
        /// <summary>
        /// Initializes a new instance of the <see cref="Weights" /> class.
        /// </summary>
        public Weights()
        {
        }
       
        /// <summary>
        /// enum to specify measurements
        /// </summary>
        public enum Unit 
        { 
            /// <summary>
            /// for measurement of kilogram
            /// </summary>
            kilogram,

            /// <summary>
            /// for measurement of grams
            /// </summary>
            Grams,

            /// <summary>
            /// for measurement of Tone
            /// </summary>
            Tonne,

            /// <summary>
            /// for measurement of kilogram TO grams
            /// </summary>
            KilogramToGrams,

            /// <summary>
            /// for measurement of Tone To kilogram
            /// </summary>
            TonneToKilograms
        }

        /// <summary>
        /// Method to convert one volume to another
        /// </summary>
        /// <param name="unit">defines which unit used</param>
        /// <param name="weights">weights for conversion</param>
        /// <returns>returns value after calculation</returns>
        public double ConvertWeigths(Unit unit, double weights)
        {
            try
            {
                if (unit.Equals(Unit.KilogramToGrams) || unit.Equals(Unit.TonneToKilograms))
                {
                    return weights * 1000;
                }

                return weights;
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
    }
}
