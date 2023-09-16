﻿using Microsoft.Data.SqlClient;
using Movie.Models;
using Movie.Repository;
using Movie.Service.Interfaces;
using System.Data;
using System.Diagnostics.Metrics;

namespace Movie.Service
{
    public class CountryService : GenericRepository<CountryModel>, ICountryService
    {
        public async Task AddCountry(CountryModel country)
        {
            await POSTProcedure("sp_addCountry", country.Country);
        }

        public async Task DeleteCountry(int id)
        {
            await POSTQuery($"DELETE FROM Country WHERE CountryId = ${id}");
        }

        public async Task<List<CountryModel>> GetAllCountries()
        {
            var allCountries = await GETAllAsyncProcedure("sp_getAllSpecifcCountries", 118, 258);
            return allCountries;
        }

        public async Task<CountryModel> GetCountry(int id)
        {
            var result = await GETSingleAsyncProcedure("sp_getSingleCountry", 118);
            return result;
        }

        public Task UpdateCountry(CountryModel country)
        {
            throw new NotImplementedException();
        }
    }


}
