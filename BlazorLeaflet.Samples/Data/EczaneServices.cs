using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorLeaflet.Samples.Data;

namespace BlazorLeaflet.Samples.Data
{

    public class EczaneServices
    {
        #region Private members
        private EczaneDbContext dbContext;
       
        List<Eczane> Eczanes = new List<Eczane>();
     

        #endregion
        #region Constructor
        public EczaneServices(EczaneDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        #endregion
        #region Public methods
        /// <summary>
        /// This method returns the list of eczane
        /// </summary>
        /// <returns></returns>
        public async Task<List<Eczane>> GetEczaneAsync()
        {
            return await dbContext.Eczane.ToListAsync();
        }
        /// <summary>
        /// This method add a new eczane to the DbContext and saves it
        /// </summary>
        /// <param name="eczane"></param>
        /// <returns></returns>
        public async Task<Eczane> AddEczaneAsync(Eczane eczane)
        {
            try
            {
                dbContext.Eczane.Add(eczane);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return eczane;
        }
        /// <summary>
        /// This method update and existing eczane and saves the changes
        /// </summary>
        /// <param name="eczane"></param>
        /// <returns></returns>
        public async Task<Eczane> UpdateEczaneAsync(Eczane eczane)
        {
            try
            {
                var eczaneExist = dbContext.Eczane.FirstOrDefault(p => p.Id == eczane.Id);
                if (eczaneExist != null)
                {
                    dbContext.Update(eczane);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return eczane;
        }
        /// <summary>
        /// This method removes and existing eczane from the DbContext and saves it
        /// </summary>
        /// <param name="eczane"></param>
        /// <returns></returns>
        public async Task DeleteEczaneAsync(Eczane eczane)
        {
            try
            {
                dbContext.Eczane.Remove(eczane);
                await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        public Eczane FindEczane(string name)
        {
            Eczanes = dbContext.Eczane.ToList();
            return Eczanes.FirstOrDefault(c =>
                string.Equals(c.Name, name, StringComparison.InvariantCultureIgnoreCase));
        }

     
       

    }
    
}
