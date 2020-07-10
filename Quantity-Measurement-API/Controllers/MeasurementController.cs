using System;
using System.Collections.Generic;
using BusinessLayer;
using BusinessLayer.Interface;
using CommanLayer;
using CommanLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace Quantity_Measurement_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        public IQuantityMeasurementBL businessLayer;

        public MeasurementController(IQuantityMeasurementBL BusinessDependencyInjection)
        {
            businessLayer = BusinessDependencyInjection;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Quantity>> GetAllQuantity()
        {
            try
            {
                var result = businessLayer.GetAllQuantity();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data is Extacted Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Sorry, Not able to Extract Data";
                    return this.NotFound(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpGet("{Id}")]
        public IActionResult GetQuantityById(int Id)
        {
            try
            {
                var result = businessLayer.GetQuantityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Conversion Data found ";
                    return this.Ok(new { success, message, Data = result });
                }
                else                                          
                {
                    bool success = false;
                    var message = "Conversion Data is not found";
                    return this.Ok(new { success, message, Data = result });
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Convert([FromBody] Quantity quantity)
        {
            try
            {
                var result = businessLayer.Convert(quantity);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "New Data Added Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "New Data is not Added";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteQuntityById(int Id)
        {
            try
            {
                var result = businessLayer.DeleteQuntityById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data is deleted sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Data is not deleted";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

       

        [HttpGet]
        [Route("compare")]
        public ActionResult<IEnumerable<Quantity>> GetAllComparison()
        {
            try
            {
                var result = businessLayer.GetAllComparison();
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data is Extacted Sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Sorry, Not able to Extract Data";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpGet]
        [Route("compare/{Id}")]
        public IActionResult GetComparisonById(int Id)
        {
            try
            {
                var result = businessLayer.GetComparisonById(Id);
                if (!result.Equals(null))
                {
                    var success = true;
                    var message = "Conversion Data found ";
                    return this.Ok(new { success, message, Data = result });
                }
                else
                {
                    var success = false;
                    var message = "Conversion Data is not found";
                    return this.Ok(new { success, message, Data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpPost]
        [Route("compare")]
        public IActionResult AddComparedValue([FromBody] Compare Info)
        {
            try
            {
                var result = businessLayer.AddComparedValue(Info);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "new data is added sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "new data is not added.";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }

        [HttpDelete]
        [Route("compare/{Id}")]
        public IActionResult DeleteComparisonById(int Id)
        {
            try
            {
                var result = businessLayer.DeleteComparisonById(Id);
                if (!result.Equals(null))
                {
                    bool success = true;
                    var message = "Data is deleted sucessfully";
                    return this.Ok(new { success, message, data = result });
                }
                else
                {
                    bool success = false;
                    var message = "Data is not deleted";
                    return this.Ok(new { success, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool success = false;
                return BadRequest(new { success, message = e.Message });
            }
        }
    }
}
