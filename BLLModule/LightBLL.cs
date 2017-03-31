using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DALModule;
namespace BLLModule
{
    public class LightBLL
    {        
        public static bool Create(int lightId, bool status)
        {
            var light = new Light
            {
                LightId = lightId,
                Status = status,
            };
            return LightDAL.Insert(light);
        }
        public static bool SetStatus(int lightId, bool status)
        {
            var light = new Light
            {
                LightId = lightId,
                Status = status,
            };
            return LightDAL.Update(light);
        }
        public static bool GetStatus(int lightId)
        {
            var light = LightDAL.Select(lightId);
            if (light == null)
                return false;
            return light.Status;
        }
    }
}
