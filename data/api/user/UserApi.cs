using DiplomaOborotovIS.data.api.model.user;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using System;
using Hanssens.Net;
using Newtonsoft.Json;

namespace diplomaISPr22_33_PankovEA.data.api.user
{
    internal class UserApi
    {
        private readonly HttpClient httpClient = new();
        private readonly LocalStorage localStorage = new();

        public UserRole GetUserRole()
        {
            return localStorage.Get<AuthResponse>("token").Role;
        }

        public string GetUsername()
        {
            return localStorage.Get<AuthResponse>("token").Username;
        }

        public void SignOut()
        {
            localStorage.Clear();
            localStorage.Dispose();
        }

        public bool IsAuth()
        {
            try
            {
                var token = localStorage.Get<AuthResponse>("token");

                if (token == null)
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public AuthResponse auth(AuthBody body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/Authorization\r\n");

            request.Content = JsonContent.Create(body);

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<AuthResponse>(json);

            localStorage.Store("token", result);
            localStorage.Dispose();

            return result;
        }

        public AuthResponse? reag(RegistrationBody body)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5000/api/Registration");

            request.Content = JsonContent.Create(body);

            var response = httpClient.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                return auth(new AuthBody
                {
                    Login = body.Login,
                    Password = body.Password
                });
            }

            return null;
        }

        public User getUser()
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:5000/api/User");

            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<User>(json);
        }

        public User UpdateUser(UpdateUserModel model)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:5000/api/User");

            request.Content = JsonContent.Create(model);
            request.Headers.TryAddWithoutValidation("Authorization", $"Bearer {token}");

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<User>(json);
        }

        public List<User> GetUsers(string? search = null, string? role = null)
        {
            var builder = new UriBuilder("http://localhost:5000/api/Users");

            var query = HttpUtility.ParseQueryString(builder.Query);
            query["search"] = search;
            query["role"] = role;
            builder.Query = query.ToString();

            var url = builder.ToString();

            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = httpClient.SendAsync(request).Result;

            var json = response.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public void updatePhoto(byte[] photo)
        {
            var token = localStorage.Get<AuthResponse>("token").Access_token;

            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(photo);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");
            requestContent.Add(imageContent, "file", "file.jpg");

            httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
            var response = httpClient.PatchAsync("http://localhost:5000/api/User/Photo", requestContent).Result;
        }
    }
}
