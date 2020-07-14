using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommanLayer;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Quantity_Measurement_API.Controllers;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using Xunit;

namespace QuantityMeasurementTesting
{
    public class QuantityMeasurementUnitTest
    {
        private MeasurementController measurementController;

        private IQuantityMeasurementBL quantityMeasurementBL;
        private IQuantityMeasurementRL quantityMeasurementRL;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeManagementTesting" /> class.
        /// </summary>
        public QuantityMeasurementUnitTest()
        {
            this.quantityMeasurementRL = new QuantityMeasurementRL();
            this.quantityMeasurementBL = new QuantityMeasurementBL(this.quantityMeasurementRL);
            this.measurementController = new MeasurementController(this.quantityMeasurementBL);
        }
        
        [Fact]
        public void GetMethod__WhenCalledGetAllQuantities_ShouldReturnOkResult()
        {
            try
            {
                // Act
                var data = measurementController.GetAllQuantity();

                // Assert
                Assert.IsType<OkObjectResult>(data);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenLengthUnitData_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(quantityMeasurementBL);
                var result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToInch",
                    Value = 1
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [Fact]
        public void GivenWeightUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(quantityMeasurementBL);
                var result = new Quantity
                {
                    MeasurementType = "weight",
                    ConversionType = "KilogramToGrams",
                    Value = 2
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Weight Unit Mililiter to Liter Conversion
        /// </summary>
        [Fact]
        public void GivenVolumeUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(quantityMeasurementBL);
                var result = new Quantity
                {
                    MeasurementType = "volume",
                    ConversionType = "LiterToMililiter",
                    Value = 2
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Degree Unit Farenhit to Celcius Conversion
        /// </summary>
        [Fact]
        public void GivenDegreeUnit_WhenQuantityOptionType_PassResult_Ok()
        {
            try
            {
                var controller = new MeasurementController(quantityMeasurementBL);
                var result = new Quantity
                {
                    MeasurementType = "length",
                    ConversionType = "FeetToCentimeter",
                    Value = 5
                };
                var okResult = controller.Convert(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        ///Test Case for Two Length Units Comparison
        /// </summary>
        [Fact]
        public void GivenLengthUnitData_WhenComparison_PassResult()
        {
            try
            {
                var controller = new MeasurementController(quantityMeasurementBL);
                var result = new Compare
                {
                    MeasurementType = "length",
                    First_Value_Unit = "FeetToInch",
                    First_Value = 3,
                    Second_Value_Unit = "YardToInch",
                    Second_Value = 1,

                };
                var okResult = controller.AddComparedValue(result);
                Assert.IsType<OkObjectResult>(okResult);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}