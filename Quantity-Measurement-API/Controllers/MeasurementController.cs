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

                //if entry is not equal to null
                if (!result.Equals(null))
                {
                    bool status = true;
                    var message = "Data is Extacted Sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else
                {
                    bool status = false;
                    var message = "Sorry, Not able to Extract Data";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
            }
        }

        [HttpPost]
        public IActionResult Convert([FromBody] Quantity quantity)
        {
            try
            {
                var result = businessLayer.Convert(quantity);
  
                //if entry is not equal to null
                if (!result.Equals(null))
                {
                    bool status = true;
                    var message = "New Data Added Sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else                                              
                {
                    bool status = false;
                    var message = "New Data is not Added";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
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
                    bool status = true;
                    var message = "Data is deleted sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else
                {
                    bool status = false;
                    var message = "Data is not deleted";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
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
                    bool status = true;
                    var message = "new data is added sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else
                {
                    bool status = false;
                    var message = "new data is not added.";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
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
                    bool status = true;
                    var message = "Data is Extacted Sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else
                {
                    bool status = false;
                    var message = "Sorry, Not able to Extract Data";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
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
                    bool status = true;
                    var message = "Data is deleted sucessfully";
                    return this.Ok(new { status, message, data = result });
                }
                else
                {
                    bool status = false;
                    var message = "Data is not deleted";
                    return this.BadRequest(new { status, message, data = result });
                }
            }
            catch (Exception e)
            {
                bool status = false;
                return BadRequest(new { status, e.Message });
            }
        }


    }
}
