using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace AspMySite.Models.BotModel.BotActioner.OsuMethods
{
    public abstract class ReqWebMethod : IWebMethodAction
    {
        protected ReqWebMethod(string Token)
        {
            this.Token = Token;
        }

        public string LastExceptionMessage { get; private set; }

        public string LastExceptionTrace { get; private set; }

        protected string Token { get; private set; }

        public dynamic LastExceptionDataDictonary { get; private set; }

        private static readonly string HTTPs = "https://";

        protected void RequestWebMethod(string connectionStringWithArgs)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
            WebReq.Method = "GET";
            WebResponse Res = WebReq.GetResponse();
            StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = streamReader.ReadToEnd();
            streamReader.Close();
            Res.Close();
        }
        protected async Task RequestWebMethodAsync(string connectionStringWithArgs)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(HTTPs + connectionStringWithArgs);
            WebReq.Method = "GET";
            WebResponse Res = await WebReq.GetResponseAsync();
            StreamReader streamReader = new StreamReader(Res.GetResponseStream(), System.Text.Encoding.UTF8);
            string result = await streamReader.ReadToEndAsync();
            streamReader.Close();
            Res.Close();
        }
        protected void TryRequestWebMethod(string connectionStringWithArgs)
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
            }
            catch (Exception e)
            {
                LastExceptionMessage = e.Message;
                LastExceptionTrace = e.StackTrace;
                LastExceptionDataDictonary = e.Data;
            }
        }

        protected async Task TryRequestWebMethodAsync(string connectionStringWithArgs)
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
            }
            catch (Exception e)
            {
                LastExceptionMessage = e.Message;
                LastExceptionTrace = e.StackTrace;
                LastExceptionDataDictonary = e.Data;
            }
        }

    }
}