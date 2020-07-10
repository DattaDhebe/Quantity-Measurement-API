//-----------------------------------------------------------------------
// <copyright file="Volumes.cs" company="BridgeLabz Solution">
//  Copyright (c) BridgeLabz Solution. All rights reserved.
// </copyright>
// <author>Datta Dhebe</author>
//-----------------------------------------------------------------------

namespace BusinessLayer
{
    using System;

    /// <summary>
    /// class for Volume
    /// </summary>
    public class Volumes
    {

        const double GallonToLiter = 3.78;
        const double LiterToMilliliter = 1000;
        const double MilliliterToLiter = 1000;

        /// <summary>
        /// Initializes a new instance of the <see cref="Volumes" /> class.
        /// </summary>
        public Volumes()
        {
        }
      
        /// <summary>
        /// enum to specify measurements
        /// </summary>
        public enum VolumeUnit
        {
            /// <summary>
            /// Measurement for Gallon
            /// </summary>
            Gallon,

            /// <summary>
            /// Measurement for Liter
            /// </summary>
            Liter,

            /// <summary>
            /// Measurement for Milliliter
            /// </summary>
            Milliliter,

            /// <summary>
            /// enum Indicating conversion from Gallon To Liter
            /// </summary>
            GallonToLiter,

            /// <summary>
            /// enum Indicating conversion from Liter To Milliliter
            /// </summary>
            LiterToMilliliter,

            /// <summary>
            /// enum Indicating conversion from Milliliter To Liter
            /// </summary>
            MilliliterToLiter
        }

        public VolumeUnit SetUnitAndConvertVolume(string operation)
        {
            if (operation == "GallonToLiter")
            {
                return VolumeUnit.GallonToLiter;
            }

            if (operation == "LiterToMilliliter")
            {
                return VolumeUnit.LiterToMilliliter;
            }

            if (operation == "MilliliterToLiter")
            {
                return VolumeUnit.MilliliterToLiter;
            }

            return VolumeUnit.Liter; 
        }

        /// <summary>
        /// Method to convert one volume to another
        /// </summary>
        /// <param name="unit">defines which unit used</param>
        /// <param name="volume">volume for conversion</param>
        /// <returns>returns value after calculation</returns>
        public double ConvertVolumes(VolumeUnit unit, double volume)
        {
            try
            {              
                if (unit.Equals(VolumeUnit.GallonToLiter))
                {
                    return volume * GallonToLiter;
                }

                if (unit.Equals(VolumeUnit.LiterToMilliliter))
                {
                    return volume * LiterToMilliliter;
                }

                if (unit.Equals(VolumeUnit.MilliliterToLiter))
                {
                    return volume / MilliliterToLiter;
                }

                return volume;
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
