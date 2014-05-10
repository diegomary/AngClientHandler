using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
namespace CustomerHandler
{  

    public class saveCustomerhandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/json";
            List<Customer> objUser = Deserialize<List<Customer>>(context);
            string h = Serialize(objUser);
            context.Response.Write(h);           
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public T Deserialize<T>(HttpContext context)
        {
            //read the json string
            string jsonData = new StreamReader(context.Request.InputStream).ReadToEnd();
            //cast to specified objectType
            var obj = (T)new JavaScriptSerializer().Deserialize<T>(jsonData);
            //return the object
            return obj;
        }
        public string Serialize(object obj)
        {         
            //cast to specified objectType
            return new JavaScriptSerializer().Serialize(obj);          
        }      



    }
}