﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HealthyMeal.Services.Interfaces
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);
        Task<bool> UpdateItemAsync(T item);
        Task<bool> DeleteItemAsync(string id);
        Task<T> GetItemAsync(string id);
        Task<IEnumerable<T>> GetAllItemsAsync(bool forceRefresh = false);
    }
}
