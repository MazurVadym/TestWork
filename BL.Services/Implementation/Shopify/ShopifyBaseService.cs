using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BL.Objects.Shopify.Attributes;
using BL.Objects.Shopify.Common;
using BL.Objects.Shopify.Extensions;
using BL.Objects.Shopify.Interface;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;

namespace BL.Services.Implementation.Shopify
{
    public class ShopifyBaseService
    {
        protected ShopifyBaseService(ShopifySettings settings, string url)
        {
            Url = url;
            Settings = settings;
        }

        internal string Url { get; set; }

        protected ShopifySettings Settings { get; set; }

        internal virtual List<T> GetAll<T>(long id, string url = null) where T : IShopifyBaseObject
        {
            var result = new List<T>();
            List<T> response;
            var del = "?";

            if (url != null)
                del = url.Contains(".json?") ? "&" : "?";

            do
            {
                var jsonResp = Get(url != null ? $"{url}{del}limit=250&since_id={id}" : $"{Url}{del}limit=250&since_id={id}", Settings);

                response = ParseResponse<List<T>>(jsonResp);

                if (response == null) break;

                result.AddRange(response);

                if (response.Count == 250)
                {
                    id = Convert.ToInt64(response.Last().Id);
                }

            } while (response.Count == 250);

            return result;
        }

        public virtual T GetById<T>(long id, string url = null)
        {
            var resp = Get(url ?? $"{Url.Split('.')[0]}/{id}.json", Settings);

            return ParseResponse<T>(resp);
        }

        public virtual List<T> GetByIds<T>(List<long> ids, string url = null)
        {
            var idsToGet = ids.ChunkBy(250);

            var result = new List<T>();

            foreach (var idToget in idsToGet)
            {
                var resp = Get(url ?? $"{Url}?limit=250&ids={string.Join(",", idToget)}", Settings);

                var response = ParseResponse<List<T>>(resp);

                if (response != null)
                    result.AddRange(response);
            }

            return result;
        }

        private static RestClient GetClient(ShopifySettings shopifySettings)
        {
            if (shopifySettings.AuthenticationType == AuthenticationType.AccessToken)
            {
                var client = new RestClient($"https://{shopifySettings.HostName}");
                client.AddDefaultHeader("X-Shopify-Access-Token", shopifySettings.AccessToken);
                return client;
            }
            else
            {
                return new RestClient($"https://{shopifySettings.HostName}") { Authenticator = new HttpBasicAuthenticator(shopifySettings.ApiKey, shopifySettings.Password) };
            }
        }

        public static string Get(string url, ShopifySettings shopifySettings)
        {
            try
            {
                var client = GetClient(shopifySettings);

                var request = new RestRequest(url, Method.GET);
                var response = client.Execute(request);

                return response.Content;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }


        private T ParseResponse<T>(string reponse)
        {
            if (string.IsNullOrEmpty(reponse))
                return default(T);

            var args = typeof(T).GetGenericArguments();

            ShopifyRootObject shopifyRootObject;

            if (args.Length == 0)
            {
                shopifyRootObject = (ShopifyRootObject)Attribute.GetCustomAttribute(typeof(T), typeof(ShopifyRootObject));
            }
            else
            {
                shopifyRootObject = (ShopifyRootObject)Attribute.GetCustomAttribute(typeof(T).GetGenericArguments()[0], typeof(ShopifyRootObject));
            }

            if (shopifyRootObject == null)
                return JsonConvert.DeserializeObject<T>(reponse);

            if (!reponse.Contains(shopifyRootObject.Name))
                return default(T);

            var type = typeof(T);
            var inputType = typeof(T);

            var jObject = JObject.Parse(reponse);

            var first = jObject.First;

            var isSingle = false;

            if (!first.Path.EndsWith("s") && type.IsGenericType)
            {
                type = type.GetGenericArguments()[0];

                isSingle = true;
            }

            var result = first.Value<JProperty>().Value.ToObject(type);

            if (isSingle && (inputType.GetGenericTypeDefinition() == typeof(List<>)))
            {
                var x = (T)Activator.CreateInstance(typeof(T));

                x.GetType().GetMethod("Add")?.Invoke(x, new[] { result });

                return x;
            }

            return (T)result;
        }
    }
}
