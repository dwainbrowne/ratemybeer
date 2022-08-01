using ClassLibrary;
using FluentValidation.Results;
using Logic.Service;
using Logic.Validation;
using Logic.Validator;
using Microsoft.AspNetCore.Http;
using System.Dynamic;
using Utilities;
using DataStore;
using ClassLibrary.Application;
using Newtonsoft.Json;

namespace Logic
{
    public class RatingsService : AbstractService, IService
    {
        Ratings? _ratings;

        public RatingsService(IQueryCollection query, string body):base(query, body)
        {
            _store = new FileDataStore();
        }


        public async void SetDataProperties()
        {
            _ratings = DataExtractor.Extract<Ratings>(_body);
        }

        public bool IsValid()
        {
            if (_ratings != null)
            {
                RatingsValidator validator = new RatingsValidator();
                ValidationResult result = validator.Validate(_ratings);

                if (!result.IsValid)
                    throw new Exception(result.ToString());
            }
            else
                throw new Exception("No ratings data");

           return true;
        }

        /// <summary>
        /// Save ratings to local database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ApplicationResponse> StoreData()
        {
            try
            {
                List<Ratings> ratingsdata = new List<Ratings>();
               

                //Validate we have a file we can save to
                await EnsureFileStoreExist();

                //Append new data to file
                string json = await AppendDataToPreviouslySavedRecord(ratingsdata);


                //Save data
                dynamic results = await _store.Create(json, DataStoreContainer.ratings);

                _response.Success = true;
                _response.Message = "Succesfully saved data to file";
                _response.Total = ratingsdata?.Count;
                _response.Data = JsonConvert.DeserializeObject<List<Ratings>>(results);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to save file to disk: {e.Message}",e);
            }

            return _response;
        }

        private async Task<string> AppendDataToPreviouslySavedRecord(List<Ratings> ratingsdata)
        {
            ratingsdata = await _store.Read<Ratings>(DataStoreContainer.ratings);


            if (ratingsdata != null && _ratings != null)
                ratingsdata.Add(_ratings);
            

            return JsonConvert.SerializeObject(ratingsdata); ;
        }

        public async Task EnsureFileStoreExist()
        {
            //Ensure we have a file on disk
            string? path = Environment.GetEnvironmentVariable("JsonFilePath");

            //Create an empty file if not exist
            if (!File.Exists(path))
                await _store.Create("[]", DataStoreContainer.ratings);
        }


        public async Task<ApplicationResponse> GetData(SearchQuery query)
        {
            try
            {
                List<Ratings> ratingsdata = new List<Ratings>();
                _store = new FileDataStore();

                //Validate we have a file we can save to
                await EnsureFileStoreExist();

                //Append new data to file
                string json = await AppendDataToPreviouslySavedRecord(ratingsdata);


                //Save data
                dynamic results = await _store.Create(json, DataStoreContainer.ratings);

                _response.Success = true;
                _response.Message = "Succesfully saved data to file";
                _response.Total = ratingsdata?.Count;
                _response.Data = JsonConvert.DeserializeObject<List<Ratings>>(results);
            }
            catch (Exception e)
            {
                throw new Exception($"Unable to save file to disk: {e.Message}", e);
            }

            return _response;
        }
    }
}