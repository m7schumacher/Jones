using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jones.Domain.Triggers
{
    public class Response
    {
        private string Template { get; set; }

        public Response(string template)
        {
            Template = template;    
        }

        public virtual string Get(params object[] objs)
        {
            return string.Format(Template, objs);
        }
    }
}
