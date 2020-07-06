using System;
using CommanLayer.Model;

namespace RepositoryLayer.Services
{
    public class QuantityMeasurementRL
    {
        //DBContext Refernce.
        private ApplicationDbContext dBContext;

        public QuantityMeasurementRL(ApplicationDbContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public QuantityMeasurementRL()
        {
        }

        public Quantity Add(Quantity quantity)
        {
            try
            {
                //add Data in database
                dBContext.Quantities.Add(quantity);
                //saves all changes in database
                dBContext.SaveChanges();
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
