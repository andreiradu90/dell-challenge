﻿using System;
using System.Collections.Generic;
using DellChallenge.D2.Web.Models;
using RestSharp;

namespace DellChallenge.D2.Web.Services
{
    public class ProductService : IProductService
    {
        public ProductModel Add(NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest("products", Method.POST, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public IEnumerable<ProductModel> GetAll()
        {
            
            var apiClient = new RestClient("http://localhost:5000/api");
            var apiRequest = new RestRequest("products", Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<List<ProductModel>>(apiRequest);
            return apiResponse.Data;
        }

        public ProductModel Get(string id)
        {

            var apiClient = new RestClient("http://localhost:5000/api");
            var resource = $"products/{id}";
            var apiRequest = new RestRequest(resource, Method.GET, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            return apiResponse.Data;
        }

        public void Delete(string id)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var resource = $"products/{id}";
            var apiRequest = new RestRequest(resource, Method.DELETE, DataFormat.Json);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            if (!apiResponse.IsSuccessful)
            {
                throw new Exception(apiResponse.ErrorMessage);
            }
        }

        public void Update(string id, NewProductModel newProduct)
        {
            var apiClient = new RestClient("http://localhost:5000/api");
            var resource = $"products/{id}";
            var apiRequest = new RestRequest(resource, Method.PUT, DataFormat.Json);
            apiRequest.AddJsonBody(newProduct);
            var apiResponse = apiClient.Execute<ProductModel>(apiRequest);
            if (!apiResponse.IsSuccessful)
            {
                throw new Exception(apiResponse.ErrorMessage);
            }
        }
    }
}
