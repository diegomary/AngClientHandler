using System;
using System.Collections.Generic;
using System.Web;
using Newtonsoft.Json;

namespace CustomerHandler
{
    public class Customer
    {
        public string name { get; set; }
        public string city { get; set; }
    }


    public class CustomerHandler : IHttpHandler
    {
        /// <summary>
        /// You will need to configure this handler in the Web.config file of your 
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpHandler Members

        public bool IsReusable
        {
            // Return false in case your Managed Handler cannot be reused for another request.
            // Usually this would be false in case you have some state information preserved per request.
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";       
            List<Customer> th = new List<Customer>();
            th.Add(new Customer { name = "Ziggy stardust", city = "Chicago" });
            th.Add(new Customer { name = "Heedy Wahlin", city = "Chandler" });
            th.Add(new Customer { name = "Dave Jones", city = "Phoenix" });
            th.Add(new Customer { name = "Jamie Riley", city = "Atlanta" });
            th.Add(new Customer { name = "Thomas Winter", city = "Seattle" });
            context.Response.ContentType = "text/json";
            context.Response.Write(JsonConvert.SerializeObject(th));
        }

        #endregion
    }
}