using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Objects.Shopify.Common
{
    /// <summary>
    /// Class ShopifySettings.
    /// </summary>
    public class ShopifySettings
    {
        public AuthenticationType AuthenticationType { get; set; } = AuthenticationType.BasicAuthentication;

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        /// <value>The password.</value>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>The name of the host.</value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the API key.
        /// </summary>
        /// <value>The API key.</value>
        //Add a comment to this line
        public string ApiKey { get; set; }

        /// Gets or sets the password.
        /// Add a comment to this line
        /// </summary>
        /// <value>The password.</value>
        public string Password { get; set; }

        public ShopifySettings(string hostName, string apiKey, string password)
        {
            AuthenticationType = AuthenticationType.BasicAuthentication;
            HostName = hostName;
            ApiKey = apiKey;
            Password = password;
        }

        public ShopifySettings(string hostName, string accessToken)
        {
            AuthenticationType = AuthenticationType.AccessToken;
            HostName = hostName;
            AccessToken = accessToken;
        }

        public ShopifySettings() { }
    }

    public enum AuthenticationType
    {
        BasicAuthentication,
        AccessToken
    }
}
