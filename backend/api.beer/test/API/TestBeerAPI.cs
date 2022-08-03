using ClassLibrary;
using DataStore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.API
{
    /// <summary>
    /// Test responsible for validating api request
    /// </summary>
    [TestClass]
    public class TestBeerAPI
    {
        IDataStore _store = new APIDataStore();
        
        [TestMethod]
        public async Task Can_Validate_Beer_Id()
        {
            Beer? beer = await _store.Get<Beer>("1",DataStoreContainer.beer);

            Assert.IsNotNull(beer);
            Assert.AreEqual("1", beer.Id);
        }


        [TestMethod]
        public async Task Can_Search_for_Beer()
        {
            string keyword = "buzz";

            List<Beer> beers = await _store.Read<Beer>(DataStoreContainer.beer, where:$"beers?beer_name={keyword}");

            Assert.IsNotNull(beers);
            Assert.IsTrue(beers[0].Name.ToLower().Contains(keyword));
        }
    }    
   
}
