using Swiss.Utilities.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Internal.API
{
    public abstract class BaseAPI
    {
        protected string Key { get; set; }
        protected string BaseURL { get; set; }

        public BaseAPI(string key = "")
        {
            Key = key;
        }

        protected string FormatBaseURL(params object[] args)
        {
            return string.Format(BaseURL, args);
        }

        protected K Deserialize<K>(string url)
        {
            try
            {
                return InternetUtility.DeserializeResponse<K>(url);
            }
            catch (Exception e)
            {
                return default(K);
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
