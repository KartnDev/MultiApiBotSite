using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AspMySite.Models.BotModel.BotListener.VkListener.WebApiReader
{
    public abstract class ReadApiMethods : IWebReadMethod
    {

        protected ReadApiMethods(string Token)
        {
            this.Token = Token;
        }


        private static readonly string HTTPs = "https://";

        protected string Token { get; private set; }
        public string LastExceptionMessage { get; private set; }

        public string LastExceptionTrace { get; private set; }

        public dynamic LastExceptionDataDictonary { get; private set; }



        public dynamic ReadWebMethod(string connectionStringWithArgs)
        {
            
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
            WebReq.Method = "GET";
            WebResponse Res = WebReq.GetResponse();
            StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            Res.Close();
            return JObject.Parse(result);
        }

        public async Task<dynamic> ReadWebMethodAsync(string connectionStringWithArgs)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
            WebReq.Method = "GET";
            WebResponse Res = await WebReq.GetResponseAsync();
            StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = await streamReader.ReadToEndAsync();
            streamReader.Close();
            Res.Close();
            return JObject.Parse(result);
        }

        public dynamic TryReadWebMethod(string connectionStringWithArgs)
        {
            try
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
                WebReq.Method = "GET";
                WebResponse Res = WebReq.GetResponse();
                StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = streamReader.ReadToEnd();
                streamReader.Close();
                Res.Close();
                return JObject.Parse(result);
            }
            catch(Exception e)
            {
                LastExceptionDataDictonary = e.Data;
                LastExceptionMessage = e.Message;
                LastExceptionTrace = e.StackTrace;
            }
            return null;
        }

        public async Task<dynamic> TryReadWebMethodAsync(string connectionStringWithArgs)
        {
            try
            {
                HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
                WebReq.Method = "GET";
                WebResponse Res = await WebReq.GetResponseAsync();
                StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
                string result = await streamReader.ReadToEndAsync();
                streamReader.Close();
                Res.Close();
                return JObject.Parse(result);
            }
            catch (Exception e)
            {
                LastExceptionDataDictonary = e.Data;
                LastExceptionMessage = e.Message;
                LastExceptionTrace = e.StackTrace;
            }
            return null;
        }
    }
}