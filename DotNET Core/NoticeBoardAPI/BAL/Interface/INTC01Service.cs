using NoticeBoardAPI.MAL;
using NoticeBoardAPI.MAL.DTO;

namespace NoticeBoardAPI.BAL.Interface
{
    /// <summary>
    /// Contains declaration of methods to perform CRUD operations for notice board 
    /// </summary>
    public interface INTC01Service
    {
        /// <summary>
        /// Enum for Add and Update
        /// </summary>
        EnumType Type { get; set; }

        /// <summary>
        /// Get all notices
        /// </summary>
        /// <returns>Response contains data of notices</returns>
        Response GetNotice();

        /// <summary>
        /// Get notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response containing notice data</returns>
        Response GetNoticeById(int id);

        /// <summary>
        /// Convert DTO to POCO before add or update operation
        /// </summary>
        /// <param name="objDTO">DTONTC01 instance</param>
        void PreSave(DTONTC01 objDTO);

        /// <summary>
        /// Validate data before add or update operation
        /// </summary>
        /// <returns>Response contains proper message if any error is occured or not</returns>
        Response Validation();

        /// <summary>
        /// Perform Add and Update operation
        /// </summary>
        /// <returns>Response contains proper message if any error is occured or not</returns>
        Response Save();

        /// <summary>
        /// Delete notice by id
        /// </summary>
        /// <param name="id">Notice id</param>
        /// <returns>Response contains is notice deleted or not</returns>
        Response Delete(int id);
    }
}
