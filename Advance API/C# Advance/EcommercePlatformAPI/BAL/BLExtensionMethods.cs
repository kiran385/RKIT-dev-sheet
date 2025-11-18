using EcommercePlatformAPI.MAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommercePlatformAPI.BAL
{
    public static class BLExtensionMethods
    {
        public static bool InStock(this PRD01 objPRD01, int buyQuantity)
        {
            return objPRD01.D01F03 >= buyQuantity;
        }
    }
}