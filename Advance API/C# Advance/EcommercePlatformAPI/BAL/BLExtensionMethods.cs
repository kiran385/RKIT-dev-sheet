using EcommercePlatformAPI.MAL.POCO;

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