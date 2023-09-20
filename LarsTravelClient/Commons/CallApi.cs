using LarsTravel.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Security.Policy;
using LarsTravelClient.Models;
using Microsoft.AspNetCore.Mvc;

namespace LarsTravelClient.Commons
{
    public class CallApi
    {
        //private readonly HttpClient _httpClient;
        //public CallApi(HttpClient httpClient)
        //{
        //    _httpClient = httpClient;
        //}
        public async Task<ResponseData> GetApi(string url)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                responseData.Success = true;
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    responseData.Message = "Yêu cầu thành công";
                    responseData.ResultData = result;
                    return responseData;
                }
                else
                {
                    responseData.Message = "Yêu cầu thất bại";
                    responseData.ResultData = null;
                    return responseData;
                }
            }
            catch (HttpRequestException e)
            {
                responseData.Success = false;
                responseData.Message = e.Message;
                responseData.ResultData = null;
                return responseData;
            }
        }

        public async Task<ResponseData> PostApi(string url, string data)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                responseData.Success = true;
                HttpContent content = new StringContent(data, null, "application/json");
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseData.Message = "Yêu cầu thành công";
                    responseData.ResultData = responseContent;
                    return responseData;
                }
                else
                {
                    responseData.Message = "Yêu cầu thất bại";
                    responseData.ResultData = null;
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.ResultData = null;
                return responseData;
            }
        }

            public async Task<ResponseData> PutApi(string url, string data)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                responseData.Success = true;
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseData.Message = "Yêu cầu thành công";
                    responseData.ResultData = responseContent;
                    return responseData;
                }
                else
                {
                    responseData.Message = "Yêu cầu thất bại";
                    responseData.ResultData = null;
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.ResultData = null;
                return responseData;
            }
        }

        public async Task<ResponseData> DeleteApi(string url)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                responseData.Success = true;
                var response = await httpClient.DeleteAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    responseData.Message = "Yêu cầu thành công";
                    responseData.ResultData = responseContent;
                    return responseData;
                }
                else
                {
                    responseData.Message = "Yêu cầu thất bại";
                    responseData.ResultData = null;
                    return responseData;
                }
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.ResultData = null;
                return responseData;
            }
        }

    }
}
