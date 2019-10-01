﻿using NEMS_API.Core.Interfaces.Data;
using NEMS_API.Core.Interfaces.Helpers;
using NEMS_API.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace NEMS_API.Data
{
    public class CacheDataReader : IDataReader
    {
        private readonly IStaticCacheHelper _staticCacheHelper;

        public CacheDataReader(IStaticCacheHelper staticCacheHelper)
        {
            _staticCacheHelper = staticCacheHelper;
        }

        public T Read<T>(T data) where T : class, IDataItem, new()
        {
            var entries = _staticCacheHelper.GetEntry<List<T>>(data.CacheKey);


            return entries?.FirstOrDefault(x => x.Id == data.Id);
        }

        public List<T> Search<T>(T data) where T : class, IDataItem, new()
        {
            var entries = _staticCacheHelper.GetEntry<List<T>>(data.CacheKey);

            //TODO: Search Criteria
            return entries ?? new List<T>();
        }

    }
}
