using System;
using System.Collections.Generic;
using BusinessLayer;
using BusinessLayer.Interface;
using CommanLayer;
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
                
                //if entry is not equal to null
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
