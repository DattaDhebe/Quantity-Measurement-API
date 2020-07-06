using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using CommanLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace QuantityMeasurementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        IQuantityMeasurementBL businessLayer;

        public MeasurementController(IQuantityMeasurementBL BusinessDependencyInjection)
        {
            businessLayer = BusinessDependencyInjection;
        }

        /// <summary>
        /// Method to Add Conversion Detail
        /// </summary>
        /// <param name="Info"></param>
        /// <returns> add conversion in database </returns>
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

    }
}
