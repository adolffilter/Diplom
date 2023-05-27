using diplomaISPr22_33_PankovEA.data.api.provider.model;
using DiplomaOborotovIS.data.api.model.user;
using Hanssens.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System;
using diplomaISPr22_33_PankovEA.data.api.order.model;
using MaterialDesignColors;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace diplomaISPr22_33_PankovEA.data.api.order
{
    internal class OrderApi
    {
        private readonly HttpClient httpClient = new();
        private readonly LocalStorage localStorage = new();

        public List<Order> GetAll(string? search = null, bool? warehouse = null)
        {
            var builder = new UriBuilder("http://localhost:5000/api/Order");

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["search"] = search;
            query["warehouse"] = warehouse.ToString();
            builder.Query = query.ToString();

            var url = builder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<Order>>(json);
        }

        public List<WarehouseOrder> GetWarehouseAll(string? search = null, WarehouseState? state = null)
        {
            var builder = new UriBuilder("http://localhost:5000/api/Order/Warehouse");

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["search"] = search;
            query["state"] = state.ToString();
            builder.Query = query.ToString();

            var url = builder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<WarehouseOrder>>(json);
        }

        public void CreateOrderWarehouse(int orderId, WarehouseState state)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var builder = new UriBuilder($"http://localhost:5000/api/Order/{orderId}/Warehouse"); 

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["state"] = state.ToString();
            builder.Query = query.ToString();

            var url = builder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Post, url);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;
        }

        public void UpdateWarehouseState(int orderWarehouseId, WarehouseState state)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var builder = new UriBuilder($"http://localhost:5000/api/Order/Warehouse/{orderWarehouseId}/State");

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["state"] = state.ToString();
            builder.Query = query.ToString();

            var url = builder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Patch, url);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine(orderWarehouseId);
            Trace.WriteLine(state);
            Trace.WriteLine(response.StatusCode);
            Trace.WriteLine(response.Content);
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
        }

        public void Add(CreateOrder body)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Post, $"http://localhost:5000/api/Order");

            request.Content = JsonContent.Create(body);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;
        }

        public void Update(int id, CreateOrder body)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Put, $"http://localhost:5000/api/Order/{id}");

            request.Content = JsonContent.Create(body);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;
        }

        public void Delete(int id)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Delete, $"http://localhost:5000/api/Order?id={id}");

            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine(id);
            Trace.WriteLine(response.StatusCode);
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
            Trace.WriteLine("text");
        }
    }
}
