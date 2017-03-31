using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DALModule
{
    public class LightDAL
    {
        static SCADADemoEntities entities = new SCADADemoEntities();
        public static bool Insert(Light light)
        {
            var lightCurrent = entities.Lights.FirstOrDefault(e => e.LightId == light.LightId);
            if (lightCurrent != null)
            {
                return true;
            }            
            entities.Lights.Add(light);
            return entities.SaveChanges() > 0;
        }

        public static bool Update(Light light)
        {
            var lightCurrent = entities.Lights.FirstOrDefault(e => e.LightId == light.LightId);
            if (lightCurrent == null)
                return false;
            lightCurrent.Status = light.Status;
            return entities.SaveChanges() > 0;
        }

        public static Light Select(int lightId)
        {
            return entities.Lights.FirstOrDefault(e => e.LightId == lightId);            
        }
    }
}
