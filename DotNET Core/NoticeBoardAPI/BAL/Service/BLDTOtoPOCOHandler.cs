using System.Reflection;

namespace NoticeBoardAPI.BAL.Service
{
    /// <summary>
    /// Contains method for convert DTO to POCO
    /// </summary>
    public static class BLDTOtoPOCOHandler
    {
        /// <summary>
        /// Convert DTO to POCO
        /// </summary>
        /// <typeparam name="POCO">POCO type</typeparam>
        /// <param name="objDTO">DTO object</param>
        /// <returns>POCO modal</returns>
        public static POCO Convert<POCO>(this object objDTO)
        {

            // As POCO Convert method is generic so we don't know about ref type
            // So get the type of the POCO
            Type pocoType = typeof(POCO);

            // Create a new instance of the POCO type
            // AS it's generic we don't know about type and can't make obj of POCO directly using new keyword
            // We typecase into POCO and use Activator to create obj
            POCO pocoInstance = (POCO)Activator.CreateInstance(pocoType);

            // Get the properties of the DTO object
            PropertyInfo[] dtoProperties = objDTO.GetType().GetProperties();

            // Get the properties of the POCO type
            PropertyInfo[] pocoProperties = pocoType.GetProperties();

            // Iterate through each property in the DTO
            foreach (PropertyInfo dtoProperty in dtoProperties)
            {
                // Find the corresponding property in the POCO with the same name
                PropertyInfo pocoProperty = Array.Find(pocoProperties, p => p.Name == dtoProperty.Name);

                // If the matching property is found and their types are compatible, copy the value
                if (pocoProperty != null && dtoProperty.PropertyType == pocoProperty.PropertyType)
                {
                    // Get the value from the DTO property
                    object value = dtoProperty.GetValue(objDTO);

                    // Set the value in the POCO property
                    pocoProperty.SetValue(pocoInstance, value);
                }
            }

            // Return the populated POCO instance
            return pocoInstance;
        }
    }
}
