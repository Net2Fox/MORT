using RestSharp;
using SharpDX.DXGI;
using System;
using System.Collections.Generic;

namespace MORT.TransAPI
{
    public class OneRingTranslatorAPI
    {
        private string _url;
        private string _transCode;
        private string _resultCode;
        private string _translatorPlugin;

        public void Init(string url, string transCode, string resultCode, string translatorPlugin)
        {
            _url = url; //example http://127.0.0.1:4990/translate
            _transCode = transCode;
            _resultCode = resultCode;
            _translatorPlugin = translatorPlugin;
        }

        public string GetResult(string original, ref bool isError)
        {
            //줄바꿈은 %0A 임
            string trim = original.Replace(" ", "");
            trim = trim.Replace(Environment.NewLine, "");
            if (trim == "")
            {
                return "";
            }

            string result = "";
            var client = new RestClient(_url);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json"); //폼 형식
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("charset", "UTF-8");

            request
                .AddParameter("text", original)
                .AddParameter("from_lang", _transCode)
                .AddParameter("to_lang", _resultCode);

            if(!string.IsNullOrWhiteSpace(_translatorPlugin))
            {
                request.AddParameter("translator_plugin", _translatorPlugin);
            }


            IRestResponse response = client.Execute(request);

            if (response == null || !response.IsSuccessful)
            {
                isError = true;
                return "error";
            }

            IDictionary<string, object> dic = (IDictionary<string, object>)SimpleJson.DeserializeObject(response.Content);

            //parse error
            string error = string.Empty;
            if (dic.ContainsKey("error"))
            {
                string errorObject = (string)dic["error"];
                if (errorObject != null)
                {
                    error = errorObject;
                    isError = true;
                    return error;
                }
            }

            //parse result
            if (dic.ContainsKey("result"))
            {
                var resultObject = dic["result"];
                if (resultObject is JsonArray)
                {
                    JsonArray resultarray = (JsonArray)resultObject;
                    for (int i = 0; i < resultarray.Count; i++)
                    {
                        result += (string)resultarray[i];
                    }
                }
                else
                {
                    result = (string)resultObject;
                }

            }
            else
            {
                result = "Empty result";
            }

            return result;
        }
    }
}
