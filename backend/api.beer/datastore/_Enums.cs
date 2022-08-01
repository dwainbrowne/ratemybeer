using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    /// <summary>
    /// DataStoreLocation stores a list of all possible location data can be stored
    /// </summary>
    public enum DataStoreLocation
    {
        DATABASE,
        FILE,
        API,
        BLOB,
        COSMOS
    }

    /// <summary>
    /// DataStoreContainer stores a list of all tables, files and/or containers in the case of cosmos db/blob storage
    /// </summary>
    public enum DataStoreContainer
    {
        beer = 1,
        attributes = 2,
        ingredients = 3,
        method = 4,
        ratings = 5
    }
}
