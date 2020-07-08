using System;
using System.Collections.Generic;
using System.Text;

namespace CommanLayer.Model
{
    public class All_Enum
    {
        public enum OptionType
        {
            InchToFeet,
            InchToYard,
            FeetToInch,
            FeetToYard,
            YardToInch,
            YardToFeet
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
