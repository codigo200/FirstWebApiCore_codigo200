using System;
using System.Collections.Generic;
using System.Text;

namespace Web.Core.Utils.HttpContext
{
    public interface IHttpCurrentContext
    {
        IDictionary<object, object> Items { get; }
        object UnBindObject(string key);
        void BindObject(string key, object Object);
    }
}
