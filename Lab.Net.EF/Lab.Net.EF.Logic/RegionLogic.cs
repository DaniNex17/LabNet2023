using Lab.Net.EF.Data;
using Lab.Net.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Net.EF.Logic
{
    public class RegionLogic : BaseLogic, IABMLogic<Region>
    {
        
        public List<Region> GetAll()
        {
            return context.Region.AsNoTracking().ToList();
        }

        public void Add(Region entity)
        {
            if (context.Region.Any(r => r.RegionID == entity.RegionID) )
            {
                throw new ArgumentException($"\nLa region con ID {entity.RegionID} ya existe.\n");
            }
            context.Region.Add(entity);
            context.SaveChanges();
        }

        public void Delete(int id) 
        {
            var regionToDelete = context.Region.Find(id);
            if (regionToDelete == null)
            {
                throw new ArgumentException($"La region con ID {id} no existe.");
            }
            context.Region.Remove(regionToDelete);
            context.SaveChanges();
        }

        public void Update(Region entity)
        {
            var regionUpdate = context.Region.Find(entity.RegionID);
            if (regionUpdate == null)
            {
                throw new ArgumentException($"La region con ID {entity.RegionID} no existe.");
            }

            regionUpdate.RegionDescription = entity.RegionDescription;
            context.SaveChanges();
        }
    }
}
