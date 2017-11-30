using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;

namespace TestWork.Models
{
    public class ApiJsonResult : IHttpActionResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="ApiJsonResult" /> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }
        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        /// <value>
        /// The status.
        /// </value>
        public HttpStatusCode ResponseCode { get; set; } = HttpStatusCode.OK;
        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public object Data { get; set; }
        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public IEnumerable<KeyValuePair<string, string[]>> Errors { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult"/> class.
        /// </summary>
        public ApiJsonResult()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult"/> class.
        /// </summary>
        /// <param name="errors">The errors.</param>
        public ApiJsonResult(ModelStateDictionary errors) : this(errors, HttpStatusCode.BadRequest)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="code">The code.</param>
        /// <param name="errors">The errors.</param>
        public ApiJsonResult(object obj, HttpStatusCode code, ModelStateDictionary errors) : this(obj, code)
        {
            if (!errors.IsValid)
            {
                Errors = errors.ToDictionary(kvp => kvp.Key,
                        kvp => kvp.Value.Errors
                            .Select(e => e.ErrorMessage).ToArray())
                    .Where(m => m.Value.Any());
            }
            else
                Errors = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult"/> class.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="code">The code.</param>
        /// <param name="errors">The errors.</param>
        public ApiJsonResult(object obj, HttpStatusCode code, IEnumerable<KeyValuePair<string, string[]>> errors) : this(obj, code)
        {
            Errors = errors;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        public ApiJsonResult(object data)
        {
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiJsonResult" /> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="status">The status.</param>
        public ApiJsonResult(object data, HttpStatusCode status)
            : this(data)
        {
            ResponseCode = status;
        }

        /// <summary>
        /// Creates an <see cref="T:System.Net.Http.HttpResponseMessage" /> asynchronously.
        /// </summary>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>
        /// A task that, when completed, contains the <see cref="T:System.Net.Http.HttpResponseMessage" />.
        /// </returns>
        /// <inheritdoc />
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(CreateResponseMessage());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HttpResponseMessage CreateResponseMessage()
        {
            if (Errors != null && Errors.Any())
                Success = false;
            else
                Success = true;

            var httpResponseMessage = new HttpResponseMessage(ResponseCode)
            {
                Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    Success = Success,
                    ResponseCode = (int)ResponseCode,
                    Errors = Errors,
                    Data = Data
                }))
            };

            httpResponseMessage.Content.Headers.ContentType.MediaType = "application/json";

            return httpResponseMessage;
        }
    }
}