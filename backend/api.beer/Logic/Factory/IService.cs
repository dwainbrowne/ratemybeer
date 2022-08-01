using ClassLibrary.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    /// <summary>
    /// Standardize Interface for all application service layer data processing
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Responsible for setting all internal properties on initial load
        /// </summary>
        void SetDataProperties();


        /// <summary>
        /// Ensure we have valid data before further processing
        /// </summary>
        /// <returns></returns>
        bool IsValid();


        /// <summary>
        /// Stores all request data
        /// </summary>
        /// <returns></returns>
        Task<ApplicationResponse> StoreData();


        /// <summary>
        /// Returns a list of records based on query
        /// </summary>
        /// <returns></returns>
        Task<ApplicationResponse> GetData(); 
    }
}
