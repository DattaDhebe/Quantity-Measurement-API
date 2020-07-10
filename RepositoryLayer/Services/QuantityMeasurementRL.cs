using System;
using System.Collections.Generic;
using System.Linq;
using CommanLayer;
using CommanLayer.Models;
using Microsoft.EntityFrameworkCore.Internal;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Services
{
    public class QuantityMeasurementRL : IQuantityMeasurementRL
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

        public IEnumerable<Quantity> GetAllQuantity()
        {
            try
            {
                return dBContext.Quantities;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity GetQuantityById(int Id)
        {
            try
            {
                //Find data from database by ID
                Quantity quantity = dBContext.Quantities.Find(Id);
                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> GetAllComparison()
        {
            try
            {
                return dBContext.Comparision;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare GetComparisonById(int Id)
        {
            try
            {
                //Find data from database by ID
                Compare compare = dBContext.Comparision.Find(Id);
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quantity Add(Quantity quantity)
        {
            try
            {
                // add data to database
                dBContext.Quantities.Add(quantity);

                // save all changes to databse
                dBContext.SaveChanges();

                return quantity;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Quantity> DeleteQuntityById(int Id)
        {
            try
            {
                List<Quantity> quantity = dBContext.Quantities.ToList();
                //Quantity quantity = dBContext.Quantities.Find(Id);
                if (quantity != null)
                {
                    //Remove Data from database
                    //dBContext.Quantities.RemoveRange();
                    dBContext.Remove(dBContext.Quantities.Single(a => a.Id == Id));
                    //saves all changes in database
                    dBContext.SaveChanges();
                }
                return GetAllQuantity();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public IEnumerable<Compare> DeleteComparisonById(int Id)
        {
            try
            {
                List<Compare> compare = dBContext.Comparision.Take(1).ToList();
                //Compare compare = dBContext.Comparision.Find(Id);
                if (compare != null)
                {
                    //Remove Data from database
                    //dBContext.Comparision.RemoveRange(compare);
                    dBContext.Remove(dBContext.Comparision.Single(a => a.Id == Id));
                    //saves all changes in database
                    dBContext.SaveChanges();
                }
                return GetAllComparison();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Compare AddComparedValue(Compare compare)
        {
            try
            {
                //send the data to database and add
                dBContext.Comparision.Add(compare);

                //saves all changes in database
                dBContext.SaveChanges();
                return compare;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
