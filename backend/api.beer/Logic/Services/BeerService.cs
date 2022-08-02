using ClassLibrary;
using ClassLibrary.Application;
using DataStore;
using Logic.Service;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Logic
{
    public class BeerService : AbstractService, IService
    {
        Beer? _beer;

        public BeerService(IQueryCollection query, string body) : base(query, body)
        {
            _store = new APIDataStore();
        }


        public async void SetDataProperties()
        {
            _beer = DataExtractor.Extract<Beer>(_body);
        }

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationResponse> StoreData()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Combine multiple results beer and comments into one
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApplicationResponse> GetData(SearchQuery query)
        {
            

            try
            {
                List<Beer> beers = new List<Beer>();
                List<Ratings> ratings = new List<Ratings>();

               

                //Get all beers based on query
                beers = await SearchBeerAPI(query);


                //Get related beer comments
                ratings = await GetBeerComments();


                dynamic results = CompostResults(beers, ratings);


                _response.Success = true;
                _response.Message = "Succesfully retrieved beer and comments";
                _response.Total = beers?.Count;
                _response.Data = results;
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to save file to disk: {e.Message}", e);
            }

            return _response;
        }


        /// <summary>
        /// For each beer find matching comments by id... **Since this is a proof of concept, each beer will have all comments...
        /// </summary>
        /// <param name="beers"></param>
        /// <param name="ratings"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private dynamic CompostResults(List<Beer> beers, List<Ratings> ratings)
        {
            dynamic results = beers.Select(b => new
            {
                b.Id,
                b.Name,
                b.Description,
                userRatings = ratings
            });

            return results;
        }

        private async Task<List<Ratings>> GetBeerComments()
        { 
             _store = new FileDataStore();

            RatingsService _ratingService = new RatingsService(_query,_body);
            await _ratingService.EnsureFileStoreExist();

            List<Ratings> ratingsdata = await _store.Read<Ratings>(DataStoreContainer.ratings);

            return ratingsdata;
        }

        private async Task<List<Beer>> SearchBeerAPI(SearchQuery query)
        {
            List<Beer> beers = new List<Beer>();

            _store = new APIDataStore();

            beers = await _store.Read<Beer>(DataStoreContainer.beer, where: "beers?beer_name=" + query.Keyword);


            return beers;
        }
    }
}
