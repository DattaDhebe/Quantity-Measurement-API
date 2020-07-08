using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.Model
{
    public class All_Enum
    {
        public enum OptionType
        {
            /// <summary>
            ///  For Length
            /// </summary>
            InchToFeet,
            InchToYard,
            FeetToInch,
            FeetToYard,
            YardToInch,
            YardToFeet,

            // For Weight
            GramToKilogram,
            GramToTonne,
            KilogramToGram,
            KilogramToTonne,
            TonneToGram
            
        }

        public enum Unit
        {
            Inch,
            Feet,
            Yard,
            Centimeter
        }
    }
}
