using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public enum DataStoreLocation
    {
        DATABASE,
        FILE,
        API,
        BLOB
    }


    public enum DataStoreContainer
    {
        beer = 1,
        attributes = 2,
        ingredients = 3,
        method = 4        
    }
}
