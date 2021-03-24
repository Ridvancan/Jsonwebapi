using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Models;


namespace WebAPI
{


    public static class ApıDal<T>
    {
        static string url = "https://northwind.now.sh/";
        public static async Task<List<T>> GetInfo(string s)
        {//Generic Kullanımı ile Web API den veri çekme.
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync($"api/{s}");
            string result = await response.Content.ReadAsStringAsync();
            List<T> t = JsonConvert.DeserializeObject<List<T>>(result);
            return t;
        }
        public static async void PostMethod(T t, string s)
        {
            //API'ye yeni kayıt oluşturma
            var convertedInf = JsonConvert.SerializeObject(t);
            var stringContent = new StringContent(convertedInf, Encoding.UTF8, "application/json");
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.PostAsync($"api/{s}", stringContent);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

            }


        }

        public static async void DeleteMethod(string s, string custid)
        {
            //Customer'ın ID'si string olduğu için overload ile özel durumda oluşacak hatalar engellendi.
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(url);

            var response = await _client.DeleteAsync($"api/{s}/{custid}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

            }
        }

        public static async void DeleteMethod(string s, int id)
        {
            //Veri silme
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri(url);

            var response = await _client.DeleteAsync($"api/{s}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

            }
        }
        public static async Task<HttpResponseMessage> PatchAsync(HttpClient client, StringContent stringContent,string s,int id)
        {//Varolan veride değişiklik yapma
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, $"https://northwind.now.sh/api/{s}/{id}")
            {
                Content = stringContent
            };
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
            }
            return response;
        }
        public static async Task<HttpResponseMessage> PatchAsync(HttpClient client, StringContent stringContent, string s, string custid)
        {//Customer'ın ID'si string olduğu için overload ile özel durumda oluşacak hatalar engellendi.
            var method = new HttpMethod("PATCH");
            var request = new HttpRequestMessage(method, $"https://northwind.now.sh/api/{s}/{custid}")
            {
                Content = stringContent
            };
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await client.SendAsync(request);
            }
            catch (TaskCanceledException e)
            {
                Console.WriteLine("ERROR: " + e.ToString());
            }
            return response;
        }

    }
    }
