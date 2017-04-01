using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.API
{
    public class API
    {
        protected string Key { get; set; }
        protected string BaseURL { get; set; }

        public API(string key = "")
        {
            Key = key;
        }

        protected string FormatBaseURL(params object[] args)
        {
            return string.Format(BaseURL, args);
        }

        protected T Deserialize<T>(string url)
        {
            try
            {
                return InternetUtility.DeserializeResponse<T>(url);
            }
            catch (Exception e)
            {
                return default(T);
            }
        }

        protected static T SafelyMakeAPICall<T>(Func<T> method)
        {
            try
            {
                var response = method();
                return response;
            }
            catch (Exception e)
            {
                return default(T);
            }
        }
    }
}
