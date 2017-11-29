using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Core.Utils.HttpContext;

namespace FirstWebApiCore.App_Start
{
    public class HttpCurrentContext : IHttpCurrentContext
    {
        private IHttpContextAccessor _httpContextAccessor;
        public HttpCurrentContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IDictionary<object, object> Items => _httpContextAccessor.HttpContext.Items;

        public object UnBindObject(string key)
        {
            var result = Items[key];
            Items[key] = null;
            return result;
        }

        public void BindObject(string key, object Object)
        {
            Items[key] = Object;
        }
    }
}
