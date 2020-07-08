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
            CentimeterToInch,

            // For Weight
            GramToKilogram,
            GramToTonne,
            KilogramToGram,
            KilogramToTonne,
            TonneToGram,

            // For Volume
            MililiterToLiter,
            LiterToMililiter,
            LiterToGallon,
            MililiterToGallon,
            GallonToLiter,
            GallonToMililiter


        }

        public enum Unit
        {
            Inch,
            Feet,
            Yard,
            Centimeter,
            Gram,
            Tonne,
            Liter,
            Gallon,
            Kilogram,
            Mililiter,
            Farenheit
        }
    }
}
